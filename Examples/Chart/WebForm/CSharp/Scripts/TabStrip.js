var selectedTab = null;

function HoverTab(tab)
{
    if(selectedTab == null)
        selectedTab = GetTabByStyleName(selectedTabStyle);
        
    if(hoveredTabStyle.length == 0)
        return;
        
    if(tab == selectedTab)
        return;
        
    tab.className = hoveredTabStyle;
}
function DefaultTab(tab)
{
    if(tabStyle.length == 0)
        return;

    if(tab == selectedTab)
        return;
        
    tab.className = tabStyle;
}

function TabStrip_TabClicked(clickIndex, tab)
{
    var form = document.forms[0];    
    if(form == null)
        return;
        
    var hidden = document.getElementById('Nevron_TabStrip_SelectedIndex');
    hidden.value = clickIndex;
    
    form.submit();
}

function GetTabByStyleName(styleName)
{
    for(i = 0; i < 100; i++)
    {
		var cell = document.getElementById("Nevron_TabStrip_NavPane_TabStrip_Tab_" + i);
        if(cell == null)
			break;
        if(cell.className == styleName)
            return cell;
    }
    
    return null;
}

