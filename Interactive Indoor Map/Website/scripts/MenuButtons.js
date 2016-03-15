function CreateButtons() {
    L.control.fullscreen({
        position: 'bottomright'
    }).addTo(geoMap);

    geoMap.on('fullscreenchange', function () {
        if (geoMap.isFullscreen()) {
            geoMap.zoomIn();
        } else {
            geoMap.zoomOut();
        }
    });

    L.easyButton('&#45;&#49;', function () {
        if (currentFloorLevel !== -1) {
            currentFloorLevel = -1;
            view.drawView();
        }
        drawFloorInfoBox();
    }, { position: 'bottomleft' }).addTo(geoMap);

    L.easyButton('&#48;', function () {
        if (currentFloorLevel !== 0) {
            currentFloorLevel = 0;
            view.drawView();
        }
        drawFloorInfoBox();

    }, { position: 'bottomleft' }).addTo(geoMap);
    L.easyButton('&#49;', function () {
        if (currentFloorLevel !== 1) {
            currentFloorLevel = 1;
            view.drawView();
        }
        drawFloorInfoBox();
    }, { position: 'bottomleft' }).addTo(geoMap);

    L.easyButton('&#50;', function () {
        drawFloorInfoBox();
        if (currentFloorLevel !== 2) {
            currentFloorLevel = 2;
            view.drawView();
        }
        drawFloorInfoBox();
    }, { position: 'bottomleft' }).addTo(geoMap);

    var buildingIcon = '<div><img src="Images/buildingIcon.png" width="25" height="25"/></div>';

    L.easyButton(buildingIcon, function () {
        drawBuildingInfo();
    }, { position: 'bottomleft' }).addTo(geoMap);
}

function CreateViewButtons() {
    var temperatureIcon = '<div><img src="Images/temperatureIcon.png" width="25" height="25"/></div>';
    var co2Icon = '<div class="buttonImage"><img src="Images/co2Icon.png" width="25" height="25"style=""/></div>';
    var lightIcon = '<div class="buttonImage"><img src="Images/lightIcon.png" width="25" height="25"style=""/></div>';
    var totalConsumptionIcon = '<div class="buttonImage"><img src="Images/totalPowerIcon.png" width="25" height="25"style=""/></div>';
    var hardwareConsumptionIcon = '<span class="buttonImage"><img src="Images/hardwarePowerIcon.png" width="25" height="25" /></span>';
    var lightConsumptionIcon = '<div class="buttonImage"><img src="Images/lightPowerIcon.png" width="25" height="25"style=""/></div>';
    var ventilationConsumptonIcon = '<div class="buttonImage"><img src="Images/ventilationPowerIcon.png" width="25" height="25"style=""/></div>';
    var otherConsumptionIcon = '<div class="buttonImage"><img src="Images/otherPowerIcon.png" width="25" height="25"style=""/></div>';
    var motionIcon = '<div class="buttonImage"><img src="Images/motionIcon.png" width="25" height="25"style=""/></div>';
    var occupantsIcon = '<div class="buttonImage"><img src="Images/occupantsIcon.png" width="25" height="25"style=""/></div>';
    var wifiClientsIcon = '<div class="buttonImage"><img src="Images/wifiIcon.png" width="25" height="25"style=""/></div>';

    L.easyButton(temperatureIcon, function () {
        if (!ViewStates.Temperature) {
            if (ViewStates.ActiveViews < 4) {
                //view.cleanup();
                //view = new TemperatureView();
                //view.drawView();
                //view.drawLegend();
                ViewStates.Temperature = true;
                ViewStates.ActiveViews++;
                drawLegend();
            }
        } else {
            ViewStates.Temperature = false;
            ViewStates.ActiveViews--;
            drawLegend();
        }

    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(co2Icon, function () {
        if (!ViewStates.CO2) {
            if (ViewStates.ActiveViews < 4) {
                ViewStates.CO2 = true;
                ViewStates.ActiveViews++;
                drawLegend();
            }
        } else {
            ViewStates.CO2 = false;
            ViewStates.ActiveViews--;
            drawLegend();
        }

    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(lightIcon, function () {
        if (!ViewStates.Light) {
            if (ViewStates.ActiveViews < 4) {
                ViewStates.Light = true;
                ViewStates.ActiveViews++;
                drawLegend();
            }
        } else {
            ViewStates.Light = false;
            ViewStates.ActiveViews--;
            drawLegend();
        }

    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(totalConsumptionIcon, function () {
        if (!ViewStates.TotalPowerConsumption) {
            if (ViewStates.ActiveViews < 4) {
                ViewStates.TotalPowerConsumption = true;
                ViewStates.ActiveViews++;
                drawLegend();
            }
        } else {
            ViewStates.TotalPowerConsumption = false;
            ViewStates.ActiveViews--;
            drawLegend();
        }
    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(hardwareConsumptionIcon, function () {
        if (!ViewStates.HardwareConsumption) {
            if (ViewStates.ActiveViews < 4) {
                ViewStates.HardwareConsumption = true;
                ViewStates.ActiveViews++;
                drawLegend();
            }
        } else {
            ViewStates.HardwareConsumption = false;
            ViewStates.ActiveViews--;
            drawLegend();
        }
    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(lightConsumptionIcon, function () {
        if (!ViewStates.LightConsumption) {
            if (ViewStates.ActiveViews < 4) {
                ViewStates.LightConsumption = true;
                ViewStates.ActiveViews++;
                drawLegend();
            }
        } else {
            ViewStates.LightConsumption = false;
            ViewStates.ActiveViews--;
            drawLegend();
        }
    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(ventilationConsumptonIcon, function () {
        if (!ViewStates.VentilationConsumption) {
            if (ViewStates.ActiveViews < 4) {
                ViewStates.VentilationConsumption = true;
                ViewStates.ActiveViews++;
                drawLegend();
            }
        } else {
            ViewStates.VentilationConsumption = false;
            ViewStates.ActiveViews--;
            drawLegend();
        }
    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(otherConsumptionIcon, function () {
        if (!ViewStates.OtherConsumption) {
            if (ViewStates.ActiveViews < 4) {
                ViewStates.OtherConsumption = true;
                ViewStates.ActiveViews++;
                drawLegend();
            }
        } else {
            ViewStates.OtherConsumption = false;
            ViewStates.ActiveViews--;
            drawLegend();
        }
    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(motionIcon, function () {
        if (!ViewStates.Motion) {
            if (ViewStates.ActiveViews < 4) {
                ViewStates.Motion = true;
                ViewStates.ActiveViews++;
                drawLegend();
            }
        } else {
            ViewStates.Motion = false;
            ViewStates.ActiveViews--;
            drawLegend();
        }
    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(occupantsIcon, function () {
        if (!ViewStates.Occupants) {
            if (ViewStates.ActiveViews < 4) {
                ViewStates.Occupants = true;
                ViewStates.ActiveViews++;
                drawLegend();
            }
        } else {
            ViewStates.Occupants = false;
            ViewStates.ActiveViews--;
            drawLegend();
        }
    }, { position: 'topright' }).addTo(geoMap);

    L.easyButton(wifiClientsIcon, function () {
        if (!ViewStates.WifiClients) {
            if (ViewStates.ActiveViews < 4) {
                ViewStates.WifiClients = true;
                ViewStates.ActiveViews++;
                drawLegend();
            }
        } else {
            ViewStates.WifiClients = false;
            ViewStates.ActiveViews--;
            drawLegend();
        }
    }, { position: 'topright' }).addTo(geoMap);
}