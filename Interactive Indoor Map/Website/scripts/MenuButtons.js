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
        if (currentFloorLevel !== -1) {
            currentFloorLevel = -1;
            view.drawView();
            if (isFloorInfoToggled) {
                onFloorInfoUpdate();
            }
        }

        //OnFloorLevelButtonClick();
    }, { position: 'bottomleft' }).addTo(geoMap);

    L.easyButton('&#48;', function () {
        if (currentFloorLevel !== 0) {
            currentFloorLevel = 0;
            view.drawView();
            if (isFloorInfoToggled) {
                onFloorInfoUpdate();
            }
        }

        //OnFloorLevelButtonClick();
    }, { position: 'bottomleft' }).addTo(geoMap);
    L.easyButton('&#49;', function () {
        if (currentFloorLevel !== 1) {
            currentFloorLevel = 1;
            view.drawView();
            if (isFloorInfoToggled) {
                onFloorInfoUpdate();
            }
        }

        //OnFloorLevelButtonClick();
    }, { position: 'bottomleft' }).addTo(geoMap);
    L.easyButton('&#50;', function () {
        if (currentFloorLevel !== 2) {
            currentFloorLevel = 2;
            view.drawView();
            if (isFloorInfoToggled) {
                onFloorInfoUpdate();
            }
        }

        //OnFloorLevelButtonClick();
    }, { position: 'bottomleft' }).addTo(geoMap);

    var imgTemp = '<div class="buttonImage"><img src="Images/temperature.png" width="25" height="25"style=""/></div>';

    L.easyButton(imgTemp, function () {
        view.cleanup();
        view = new TemperatureView();
        view.drawView();
        view.drawLegend();

    }, { position: 'bottomleft', paddingleft: "0px" }).addTo(geoMap);

}