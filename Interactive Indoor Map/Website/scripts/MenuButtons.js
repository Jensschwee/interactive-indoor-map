var currentFloorLevel = 0;

function OnFloorLevelButtonClick() {
    if (geoMap != null) {
        geoMap.removeLayer(geojson);
    }
    PageMethods.DrawFloor(currentFloorLevel, onSuccess);

    function onSuccess(response, userContext, methodName) {
        callBackMethodsToDraw(response);
    }
}

function CreateButtons() {
    L.control.fullscreen({
        position: 'bottomleft'
    }).addTo(geoMap);
    //https://github.com/brunob/leaflet.fullscreen

    L.easyButton('-1;', function () {
        currentFloorLevel = -1;
        OnFloorLevelButtonClick();
    }, { position: 'bottomleft' }).addTo(geoMap);

    L.easyButton('0;', function () {
        currentFloorLevel = 0;
        OnFloorLevelButtonClick();
    }, { position: 'bottomleft' }).addTo(geoMap);
    L.easyButton('1;', function () {
        currentFloorLevel = 1;
        OnFloorLevelButtonClick();
    }, { position: 'bottomleft' }).addTo(geoMap);
    L.easyButton('2;', function () {
        currentFloorLevel = 2;
        OnFloorLevelButtonClick();
    }, { position: 'bottomleft' }).addTo(geoMap);

    L.easyButton('Temp', function () {
        ViewTemperature();
    }, { position: 'bottomleft' }).addTo(geoMap);

}