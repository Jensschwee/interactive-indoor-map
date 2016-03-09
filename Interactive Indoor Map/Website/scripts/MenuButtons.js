var viewSet = new Set();

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
        position: 'bottomright'
    }).addTo(geoMap);

    //https://github.com/brunob/leaflet.fullscreen

    L.easyButton('&#45;&#49;', function () {
        if (currentFloorLevel !== -1) {
            currentFloorLevel = -1;
            view.drawView();
            drawFloorInfoBox();
        }
    }, { position: 'bottomleft' }).addTo(geoMap);

    L.easyButton('&#48;', function () {
        if (currentFloorLevel !== 0) {
            currentFloorLevel = 0;
            view.drawView();
            drawFloorInfoBox();

        }
    }, { position: 'bottomleft' }).addTo(geoMap);
    L.easyButton('&#49;', function () {
        if (currentFloorLevel !== 1) {
            currentFloorLevel = 1;
            view.drawView();
            drawFloorInfoBox()
        }
    }, { position: 'bottomleft' }).addTo(geoMap);

    L.easyButton('&#50;', function () {
        if (currentFloorLevel !== 2) {
            currentFloorLevel = 2;
            view.drawView();
            drawFloorInfoBox();
        }
    }, { position: 'bottomleft' }).addTo(geoMap);

    L.easyButton('B;', function () {
        drawBuildingInfo();
    }, { position: 'bottomleft' }).addTo(geoMap);
}

function CreateViewButtons() {
    var temperatureIcon = '<div class="buttonImage"><img src="Images/temperature.png" width="25" height="25"style=""/></div>';
    var co2Icon = '<div class="buttonImage"><img src="Images/temperature.png" width="25" height="25"style=""/></div>';
    var lightIcon = '<div class="buttonImage"><img src="Images/temperature.png" width="25" height="25"style=""/></div>';
    var hardwareConsumptionIcon = '<div class="buttonImage"><img src="Images/temperature.png" width="25" height="25"style=""/></div>';
    var lightConsumptionIcon = '<div class="buttonImage"><img src="Images/temperature.png" width="25" height="25"style=""/></div>';
    var ventilationConsumptonIcon = '<div class="buttonImage"><img src="Images/temperature.png" width="25" height="25"style=""/></div>';
    var otherConsumptionIcon = '<div class="buttonImage"><img src="Images/temperature.png" width="25" height="25"style=""/></div>';
    var motionIcon = '<div class="buttonImage"><img src="Images/temperature.png" width="25" height="25"style=""/></div>';
    var occupantsIcon = '<div class="buttonImage"><img src="Images/temperature.png" width="25" height="25"style=""/></div>';
    var wifiClientsIcon = '<div class="buttonImage"><img src="Images/temperature.png" width="25" height="25"style=""/></div>';

    L.easyButton(temperatureIcon, function () {
        if (!ViewStates.temperature) {
            view.cleanup();
            view = new TemperatureView();
            view.drawView();
            view.drawLegend();
            ViewStates.Temperature = true;
            console.log('on');
            console.log('temperature state: ' + ViewStates.temperature);
        } else {
            ViewStates.Temperature = false;
            console.log('off');
            console.log('temperature state: ' + ViewStates.temperature);
        }

    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(co2Icon, function () {
        if (!ViewStates.CO2) {
            ViewStates.CO2 = true;
        } else {
            ViewStates.CO2 = false;
        }

    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(lightIcon, function () {
        if (!ViewStates.Light) {
            ViewStates.Light = true;
        } else {
            ViewStates.Light = false;
        }

    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(hardwareConsumptionIcon, function () {
        if (!ViewStates.HardwareConsumption) {
            ViewStates.HardwareConsumption = true;
        } else {
            ViewStates.HardwareConsumption = false;
        }
    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(lightConsumptionIcon, function () {
        if (!ViewStates.LightConsumption) {
            ViewStates.LightConsumption = true;
        } else {
            ViewStates.LightConsumption = false;
        }
    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(ventilationConsumptonIcon, function () {
        if (!ViewStates.VentilationConsumption) {
            ViewStates.VentilationConsumption = true;
        } else {
            ViewStates.VentilationConsumption = false;
        }
    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(otherConsumptionIcon, function () {
        if (!ViewStates.OtherConsumption) {
            ViewStates.OtherConsumption = true;
        } else {
            ViewStates.OtherConsumption = false;
        }
    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(motionIcon, function () {
        if (!ViewStates.Motion) {
            ViewStates.Motion = true;
        } else {
            ViewStates.Motion = false;
        }
    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(occupantsIcon, function () {
        if (!ViewStates.Occupants) {
            ViewStates.Occupants = true;
        } else {
            ViewStates.Occupants = false;
        }
    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(wifiClientsIcon, function () {
        if (!ViewStates.WifiClients) {
            ViewStates.WifiClients = true;
        } else {
            ViewStates.WifiClients = false;
        }
    }, { position: 'topright' }).addTo(geoMap);
}