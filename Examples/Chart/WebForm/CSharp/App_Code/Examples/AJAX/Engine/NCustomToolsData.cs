using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Nevron.Examples.Chart.WebForm
{
	public class NCustomToolsData
	{
		#region Nested Classes

		public class NData
		{
			public void ImportAgeRanges(ArrayList rows)
			{
				int length = rows.Count;
				for (int i = 0; i < length; i++)
				{
					Dictionary<string, int> row = rows[i] as Dictionary<string, int>;
					string title;
					int startAge = row["start age"];
					int endAge = row["end age"];
					
					if(startAge == 0)
						title = string.Format("under {0}", endAge);
					else if (endAge >= 99)
						title = string.Format("{0}+", startAge);
					else if (startAge + 1 == endAge)
						title = string.Format("{0}, {1}", startAge, endAge);
					else
						title = string.Format("{0} to {1}", startAge, endAge);

					NAgeRange ageRange = new NAgeRange(i, title, startAge, endAge);
					AgeRanges.Add(ageRange);
				}
			}

			public void ImportRaces(ArrayList rows)
			{
				//	import all races
				NRace caucasian = new NRace(0, "Caucasian");
				Races.Add(caucasian);
				caucasian.MaleData.Import(AgeRanges, rows, "white male pop", "white male err");
				caucasian.FemaleData.Import(AgeRanges, rows, "white female pop", "white female err");

				NRace black = new NRace(1, "Black");
				Races.Add(black);
				black.MaleData.Import(AgeRanges, rows, "black male pop", "black male err");
				black.FemaleData.Import(AgeRanges, rows, "black female pop", "black female err");

				NRace nativeAmerican = new NRace(2, "Native American");
				Races.Add(nativeAmerican);
				nativeAmerican.MaleData.Import(AgeRanges, rows, "indian + alaska male pop", "indian + alaska male err");
				nativeAmerican.FemaleData.Import(AgeRanges, rows, "indian + alaska female pop", "indian + alaska female err");

				NRace asian = new NRace(3, "Asian");
				Races.Add(asian);
				asian.MaleData.Import(AgeRanges, rows, "asian male pop", "asian male err");
				asian.FemaleData.Import(AgeRanges, rows, "asian female pop", "asian female err");

				NRace pacificNatvies = new NRace(4, "Pacific Natives");
				Races.Add(pacificNatvies);
				pacificNatvies.MaleData.Import(AgeRanges, rows, "pacific male pop", "pacific male err");
				pacificNatvies.FemaleData.Import(AgeRanges, rows, "pacific female pop", "pacific female err");

				NRace otherSomeRace = new NRace(5, "Other Some Race");
				Races.Add(otherSomeRace);
				otherSomeRace.MaleData.Import(AgeRanges, rows, "race male pop", "race male err");
				otherSomeRace.FemaleData.Import(AgeRanges, rows, "race female pop", "race female err");

				NRace twoOrMoreRaces = new NRace(6, "Two or More Races");
				Races.Add(twoOrMoreRaces);
				twoOrMoreRaces.MaleData.Import(AgeRanges, rows, "mixed male pop", "mixed male err");
				twoOrMoreRaces.FemaleData.Import(AgeRanges, rows, "mixed female pop", "mixed female err");

				//	calculate the totals
				int rowsLength = rows.Count;
				for (int j = 0; j < rowsLength; j++)
				{
					int totalMalePopulation = 0;
					int totalFemalePopulation = 0;
					int totalMaleError = 0;
					int totalFemaleError = 0;

					int racesLength = Races.Count;
					for (int i = 0; i < racesLength; i++)
					{
						totalMalePopulation += Races[i].MaleData.Rows[j].Value;
						totalFemalePopulation += Races[i].FemaleData.Rows[j].Value;
						totalMaleError += Races[i].MaleData.Rows[j].Error;
						totalFemaleError += Races[i].FemaleData.Rows[j].Error;
					}

					TotalMaleData.Rows.Add(new NPopulationDataEntry(AgeRanges[j], totalMalePopulation, totalMaleError));
					TotalFemaleData.Rows.Add(new NPopulationDataEntry(AgeRanges[j], totalFemalePopulation, totalFemaleError));
				}
			}

			public List<NAgeRange> AgeRanges = new List<NAgeRange>();
			public List<NRace> Races = new List<NRace>();

			public NPopulationData TotalMaleData = new NPopulationData(0, "Male");
			public NPopulationData TotalFemaleData = new NPopulationData(1, "Female");
		}

		public class NRace
		{
			public NRace(int id, string title)
			{
				Id = id;
				Title = title;
			}

			public int Id;
			public string Title;

			public NPopulationData MaleData = new NPopulationData(0, "Male");
			public NPopulationData FemaleData = new NPopulationData(1, "Female");
		}

		public class NPopulationData
		{
			public NPopulationData(int id, string title)
			{
				Id = id;
				Title = title;
			}

			public void Import(List<NAgeRange> ageRanges, ArrayList rows, string valueColumn, string errorColumn)
			{
				int length = rows.Count;
				for (int i = 0; i < length; i++)
				{
					NAgeRange ageRange = ageRanges[i];
					Dictionary<string, int> row = rows[i] as Dictionary<string, int>;

					Rows.Add(new NPopulationDataEntry(ageRange, row[valueColumn], row[errorColumn]));
				}
			}

			public int Id;
			public string Title;

			public List<NPopulationDataEntry> Rows = new List<NPopulationDataEntry>();
		}

		public class NAgeRange
		{
			public NAgeRange(int id, string title, int start, int end)
			{
				Id = id;
				Title = title;
				Start = start;
				End = end;
			}

			public int Id;
			public string Title;
			public int Start;
			public int End;
		}

		public class NPopulationDataEntry
		{
			public NPopulationDataEntry(NAgeRange ageRange, int value, int error)
			{
				AgeRange = ageRange;
				Value = value;
				Error = error;
			}

			public NAgeRange AgeRange;
			public int Value;
			public int Error;
		}

		#endregion

		public static NData Read()
		{
			// setup ole db connection
			string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
				HttpContext.Current.Server.MapPath(@"~\App_Data\demographicData.xls") + 
				";Extended Properties=Excel 8.0;";

			OleDbConnection oleDbConnection1 = new OleDbConnection(connectionString);

			OleDbCommand oleDbCommand1 = new OleDbCommand("SELECT * From [SHEET$]", oleDbConnection1);
			OleDbDataReader oleDbDataReader1 = null;

			ArrayList rows = new ArrayList();
			try
			{
				// execute the select command
				oleDbConnection1.Open();
				oleDbDataReader1 = oleDbCommand1.ExecuteReader();

				while (oleDbDataReader1.Read())
				{
					if (oleDbDataReader1["start age"] == DBNull.Value)
						break;

					Dictionary<string, int> row = new Dictionary<string, int>();
					rows.Add(row);

					ReadField(oleDbDataReader1, row, "start age");
					ReadField(oleDbDataReader1, row, "end age");
					ReadField(oleDbDataReader1, row, "white male pop");
					ReadField(oleDbDataReader1, row, "white male err");
					ReadField(oleDbDataReader1, row, "white female pop");
					ReadField(oleDbDataReader1, row, "white female err");
					ReadField(oleDbDataReader1, row, "black male pop");
					ReadField(oleDbDataReader1, row, "black male err");
					ReadField(oleDbDataReader1, row, "black female pop");
					ReadField(oleDbDataReader1, row, "black female err");
					ReadField(oleDbDataReader1, row, "indian + alaska male pop");
					ReadField(oleDbDataReader1, row, "indian + alaska male err");
					ReadField(oleDbDataReader1, row, "indian + alaska female pop");
					ReadField(oleDbDataReader1, row, "indian + alaska female err");
					ReadField(oleDbDataReader1, row, "asian male pop");
					ReadField(oleDbDataReader1, row, "asian male err");
					ReadField(oleDbDataReader1, row, "asian female pop");
					ReadField(oleDbDataReader1, row, "asian female err");
					ReadField(oleDbDataReader1, row, "pacific male pop");
					ReadField(oleDbDataReader1, row, "pacific male err");
					ReadField(oleDbDataReader1, row, "pacific female pop");
					ReadField(oleDbDataReader1, row, "pacific female err");
					ReadField(oleDbDataReader1, row, "race male pop");
					ReadField(oleDbDataReader1, row, "race male err");
					ReadField(oleDbDataReader1, row, "race female pop");
					ReadField(oleDbDataReader1, row, "race female err");
					ReadField(oleDbDataReader1, row, "mixed male pop");
					ReadField(oleDbDataReader1, row, "mixed male err");
					ReadField(oleDbDataReader1, row, "mixed female pop");
					ReadField(oleDbDataReader1, row, "mixed female err");
				}
			}
			finally
			{
				if (oleDbDataReader1 != null)
					oleDbDataReader1.Close();

				if (oleDbConnection1 != null)
					oleDbConnection1.Close();
			}

			//	build the data structures
			NData data = new NData();
			data.ImportAgeRanges(rows);
			data.ImportRaces(rows);

			return data;
		}

		static void ReadField(OleDbDataReader oleDbDataReader, Dictionary<string, int> row, string columnName)
		{
			object obj = oleDbDataReader[columnName];
			if (obj == DBNull.Value)
			{
				row.Add(columnName, -1);
			}
			else
			{
				row.Add(columnName, int.Parse(obj.ToString()));
			}
		}
	}
}