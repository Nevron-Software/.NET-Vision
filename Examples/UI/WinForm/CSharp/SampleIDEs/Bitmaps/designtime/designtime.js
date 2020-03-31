function hsDTLoad(){
    // set the scroll position
    try{scrollPos = load("dtscrollpos");resizeBan();HSShowAllCSections();}
    catch(e){}
}

function hsDTSave(){
    // save the scroll position
    save("dtscrollpos",documentElement("pagebody").scrollTop);
    saveSettings();
}

var isDesignTime = true;