/*
function OnFloorLevelButtonClick() {
    if (geoMap != null) {
        geoMap.removeLayer(geojson);
    }
    function onSuccess(response, userContext, methodName) {
        callBackMethodsToDraw(response);
    }

    PageMethods.DrawFloor(currentFloorLevel, onSuccess);

    if (isFloorInfoToggled) {
        onFloorInfoUpdate();
    }
}*/

function CreateButtons() {
    L.control.fullscreen({
        position: 'bottomleft'
    }).addTo(geoMap);
    //https://github.com/brunob/leaflet.fullscreen

    L.easyButton('&#45;&#49;', function () {
        currentFloorLevel = -1;
        view.drawView(currentFloorLevel);

        //OnFloorLevelButtonClick();
    }, { position: 'bottomleft' }).addTo(geoMap);

    L.easyButton('&#48;', function () {
        currentFloorLevel = 0;
        view.drawView(currentFloorLevel);

        //OnFloorLevelButtonClick();
    }, { position: 'bottomleft' }).addTo(geoMap);
    L.easyButton('&#49;', function () {
        currentFloorLevel = 1;
        view.drawView(currentFloorLevel);

        //OnFloorLevelButtonClick();
    }, { position: 'bottomleft' }).addTo(geoMap);
    L.easyButton('&#50;', function () {
        currentFloorLevel = 2;
        view.drawView(currentFloorLevel);

        //OnFloorLevelButtonClick();
    }, { position: 'bottomleft' }).addTo(geoMap);

    var imgTemp = '<img src="Images/temperature.png" width="25" height="25"style=""/>';

    L.easyButton(imgTemp, function () {
        view.cleanup();
        view = new TemperatureView();
    }, { position: 'bottomleft', paddingleft: "0px" }).addTo(geoMap);

}