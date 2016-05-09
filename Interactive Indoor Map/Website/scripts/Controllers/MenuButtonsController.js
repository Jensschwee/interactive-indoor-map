var buildingButton;
var activeViewsMax = 5;
var notContained = -1;
var TemperatureColor = "#1a53ff";  //"#8ab1c4"
var CO2Color = "#4d79ff"; //"#c7b7ea"
var LightColor = "#ffe11d"; //"#ffe11d"
var MotionDetectionColor = "#009933"; //"#b2d649"
var WifiClientsColor = "#00cc44"; //"#83bd1a"
var OccupantsColor = "#1aff66"; //"#2ecc71"
var TotalPowerConsumptionColor = "#b30000";
var HardwarePowerConsumptionColor = "#e60000";
var LightPowerConsumptionColor = "#ff1a1a";
var VentilationPowerConsumptionColor = "#ff4d4d";
var OtherPowerConsumptionColor = "#ff8080";

function CreateSpatialButtons() {
    var buildingIcon = createIconForButton("Images/buildingIcon4.png");
    var zeroIcon = createIconForButton("Images/0Icon.png");
    var oneIcon = createIconForButton("Images/1Icon.png");
    var twoIcon = createIconForButton("Images/2Icon.png");


    L.control.fullscreen({
        position: 'bottomright'
    }).addTo(geoMap);

    //fullscreenButton.button.style.width = '30px';
    //fullscreenButton.button.style.height = '30px';
    //fullscreenButton.addTo(geoMap)

    geoMap.on('fullscreenchange', function () {
        if (geoMap.isFullscreen()) {
            geoMap.zoomIn();
        } else {
            geoMap.zoomOut();
        }
    });

    /*var cellarButton = L.easyButton({
        id: 'easy-button',
        position: 'bottomright',
        states: [{
            stateName: 'None',
            icon: '&#45;&#49;',
            title: 'Cellar',
            onClick: function (btn) {
                if (currentFloorLevel !== -1) {
                    currentFloorLevel = -1;
                    changeFloor();
                }
                drawFloorInfoBox();
                btn.button.style.backgroundColor = '#8c8c8c';
                parterreButton.button.style.backgroundColor = 'white';
                groundFloorButton.button.style.backgroundColor = 'white';
                firstFloorButton.button.style.backgroundColor = 'white';
                buildingButton.button.style.backgroundColor = 'white';
            }
        }]
    }).addTo(geoMap);*/

    var parterreButton = L.easyButton({
        id: 'easy-button',
        position: 'bottomright',
        states: [{
            stateName: 'None',
            icon: zeroIcon,
            title: 'Parterre',
            onClick: function (btn) {
                if (currentFloorLevel !== 0) {
                    currentFloorLevel = 0;
                    changeFloor();
                }
                drawFloorInfoBox();
                btn.button.style.backgroundColor = '#8c8c8c';
                groundFloorButton.button.style.backgroundColor = 'white';
                firstFloorButton.button.style.backgroundColor = 'white';
                if (buildingButton.state('detoggled'))
                    buildingButton.button.click();
            }
        }]
    }).addTo(geoMap);

    var groundFloorButton = L.easyButton({
        id: 'easy-button',
        position: 'bottomright',
        states: [{
            stateName: 'None',
            icon: oneIcon,
            title: 'Ground Floor',
            onClick: function (btn) {
                if (currentFloorLevel !== 1) {
                    currentFloorLevel = 1;
                    changeFloor();
                }
                drawFloorInfoBox();
                btn.button.style.backgroundColor = '#8c8c8c';
                parterreButton.button.style.backgroundColor = 'white';
                firstFloorButton.button.style.backgroundColor = 'white';
                if (buildingButton.state('detoggled'))
                    buildingButton.button.click();
            }
        }]
    }).addTo(geoMap);

    groundFloorButton.button.style.backgroundColor = '#8c8c8c';

    var firstFloorButton = L.easyButton({
        id: 'easy-button',
        position: 'bottomright',
        states: [{
            stateName: 'None',
            icon: twoIcon,
            title: 'First Floor',
            onClick: function (btn) {
                if (currentFloorLevel !== 2) {
                    currentFloorLevel = 2;
                    changeFloor();
                }
                drawFloorInfoBox();
                btn.button.style.backgroundColor = '#8c8c8c';
                parterreButton.button.style.backgroundColor = 'white';
                groundFloorButton.button.style.backgroundColor = 'white';
                if (buildingButton.state('detoggled'))
                    buildingButton.button.click();
            }
        }]
    }).addTo(geoMap);


    buildingButton = L.easyButton({
        id: 'easy-button',
        position: 'bottomright',
        states: [{
            stateName: 'toggled',
            icon: buildingIcon,
            title: 'Building',
            onClick: function (btn) {
                drawBuildingInfoBox();
                btn.button.style.backgroundColor = '#8c8c8c';
                btn.state('detoggled');
            }
        }, {
            stateName: 'detoggled',
            icon: buildingIcon,
            title: 'Building',
            onClick: function (btn) {
                drawFloorInfoBox();
                btn.button.style.backgroundColor = 'white';
                btn.state('toggled');
            }
        }]
    }).addTo(geoMap);

    
}

function CreateTemporalButtons() {
    var temporalIcon = createIconForButton("Images/temporalIcon2.png");

    var temporalButton = L.easyButton({
        id: 'easy-button',
        position: 'bottomright',
        states: [{
            stateName: 'toggled',
            icon: temporalIcon,
            title: 'TemporalUpdater',
            onClick: function (btn) {
                btn.button.style.backgroundColor = '#8c8c8c';
                $("#DRP").show();
                btn.state('detoggled');
                temporalActive = true;
            }
        }, {
            stateName: 'detoggled',
            icon: temporalIcon,
            title: 'TemporalUpdater',
            onClick: function (btn) {
                btn.button.style.backgroundColor = 'white';
               $("#DRP").hide();
               btn.state('toggled');
               temporalActive = false;
            }
        }]
    }).addTo(geoMap);

}

function createIconForButton(imageSrc) {
    var height = 30;
    var width = 30;
    return '<div><img src="' + imageSrc + '" width="' + width + '" height="' + height + '"/></div>';
}

function CreateViewButtons() {
    var temperatureIcon = createIconForButton("Images/temperatureIcon.png");
    var co2Icon = createIconForButton("Images/co2Icon.png");
    var lightIcon = createIconForButton("Images/lightIcon.png");
    var totalConsumptionIcon = createIconForButton("Images/totalPowerIcon.png");
    var hardwareConsumptionIcon = createIconForButton("Images/hardwarePowerIcon.png");
    var lightConsumptionIcon = createIconForButton("Images/lightPowerIcon.png");
    var ventilationConsumptonIcon = createIconForButton("Images/ventilationPowerIcon.png");
    var otherConsumptionIcon = createIconForButton("Images/otherPowerIcon.png");
    var motionIcon = createIconForButton("Images/motionIcon.png");
    var occupantsIcon = createIconForButton("Images/occupantsIcon.png");
    var wifiClientsIcon = createIconForButton("Images/wifiIcon.png");
    var waterConsumptionIcon = createIconForButton("Images/waterConsumptionIcon.png");


    var toggleTempButton = L.easyButton({
        id: 'easy-button',
        states: [
            {
                icon: temperatureIcon,
                title: 'Temperature',
                stateName: 'toggled',
                onClick: function (btn) {
                    if (ActiveViews.length === activeViewsMax)
                        ActiveViews[0].button.button.click();

                    var temperatureObj = {
                        name: "Temperature",
                        color: TemperatureColor,
                        icon: temperatureIcon,
                        max: 'MaxTemperature',
                        value: 'Temperature',
                        min: "MinTemperature",
                        average: "AverageTemperature",
                        maxObserved: "MaxObservedTemperature",
                        minObservedTemperature: "MinObservedTemperature",
                        button: toggleTempButton
                    };

                    btn.button.style.backgroundColor = TemperatureColor;
                    ActiveViews.push(temperatureObj);
                    reDrawItemsOnMap();
                    btn.state('detoggled');
                    infoboxUpdate();
                }
            }, {
                icon: temperatureIcon,
                stateName: 'detoggled',
                title: 'Temperature',
                onClick: function (btn) {
                    var index = findIndexOfView("Temperature");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();

                        btn.button.style.backgroundColor = 'white';
                        btn.state('toggled');
                        infoboxUpdate();
                    }
                }
            }
        ],
        position: 'topright'
    }).addTo(geoMap);

    var toggleCO2Button = L.easyButton({
        id: 'easy-button',
        states: [
            {
                icon: co2Icon,
                stateName: 'toggled',
                title: 'CO2',
                onClick: function (btn) {
                    if (ActiveViews.length === activeViewsMax)
                        ActiveViews[0].button.button.click();
                    var co2Obj = {
                        name: "CO2",
                        color: CO2Color,
                        icon: co2Icon,
                        max: 'MaxCO2',
                        value: 'CO2',
                        min: "MinCO2",
                        average: "AverageCO2",
                        maxObserved: "MaxObservedCO2",
                        minObservedTemperature: "MinObservedCO2",
                        button: toggleCO2Button
                    };
                    btn.button.style.backgroundColor = CO2Color;
                    ActiveViews.push(co2Obj);
                    reDrawItemsOnMap();
                    btn.state('detoggled');
                    infoboxUpdate();
                }
            }, {
                icon: co2Icon,
                stateName: 'detoggled',
                title: 'CO2',
                onClick: function (btn) {
                    var index = findIndexOfView("CO2");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();

                        btn.button.style.backgroundColor = 'white';
                        btn.state('toggled');
                        infoboxUpdate();
                    }
                }
            }
        ],
        position: 'topright'
    }).addTo(geoMap);

    var toggleLightButton = L.easyButton({
        id: 'easy-button',
        states: [
            {
                icon: lightIcon,
                title: 'Lux',
                stateName: 'toggled',
                onClick: function (btn) {
                    if (ActiveViews.length === activeViewsMax)
                        ActiveViews[0].button.button.click();
                    var co2Obj = {
                        name: "Lux",
                        color: LightColor,
                        icon: lightIcon,
                        value: 'Lux',
                        max: 'MaxLux',
                        average: "AverageLux",
                        maxObserved: "MaxObservedLux",
                        minObservedTemperature: "MinObservedLux",
                        button: toggleLightButton
                    };
                    btn.button.style.backgroundColor = LightColor;
                    ActiveViews.push(co2Obj);
                    reDrawItemsOnMap();
                    btn.state('detoggled');
                    infoboxUpdate();

                }
            }, {
                icon: lightIcon,
                title: 'Lux',
                stateName: 'detoggled',
                onClick: function (btn) {
                    var index = findIndexOfView("Lux");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();

                        btn.button.style.backgroundColor = 'white';
                        btn.state('toggled');
                        infoboxUpdate();
                    }
                }
            }
        ],
        position: 'topright'
    }).addTo(geoMap);

    var toggleMotionButton = L.easyButton({
        id: 'easy-button',
        states: [
            {
                icon: motionIcon,
                title: 'Motion Detection',
                stateName: 'toggled',
                onClick: function (btn) {
                    if (ActiveViews.length === activeViewsMax)
                        ActiveViews[0].button.button.click();
                    var motionObj = {
                        name: "Motion",
                        color: MotionDetectionColor,
                        icon: motionIcon,
                        value: 'Motion',
                        average: "AverageMotion",
                        maxObserved: "MaxObservedMotion",
                        minObservedTemperature: "MinObservedMotion",
                        button: toggleMotionButton
                    };
                    btn.button.style.backgroundColor = MotionDetectionColor;
                    ActiveViews.push(motionObj);
                    reDrawItemsOnMap();
                    btn.state('detoggled');
                    infoboxUpdate();
                }
            }, {
                icon: motionIcon,
                title: 'Motion Detection',
                stateName: 'detoggled',
                onClick: function (btn) {
                    var index = findIndexOfView("Motion");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();
                        btn.button.style.backgroundColor = 'white';
                        btn.state('toggled');
                        infoboxUpdate();
                    }
                }
            }
        ],
        position: 'topright'
    }).addTo(geoMap);

    var toggleWifiClientsButton = L.easyButton({
        id: 'easy-button',
        states: [
            {
                icon: wifiClientsIcon,

                stateName: 'toggled',
                title: 'Wifi Clients',
                onClick: function (btn) {
                    if (ActiveViews.length === activeViewsMax)
                        ActiveViews[0].button.button.click();
                    var wifiClientsObj = {
                        name: "WifiClients",
                        color: WifiClientsColor,
                        icon: wifiClientsIcon,
                        max: 'MaxWifiClients',
                        value: 'WifiClients',
                        average: "AverageWifiClients",
                        maxObserved: "MaxObservedWifiClients",
                        minObservedTemperature: "MinObservedWifiClients",
                        button: toggleWifiClientsButton
                    };
                    btn.button.style.backgroundColor = WifiClientsColor;
                    ActiveViews.push(wifiClientsObj);
                    reDrawItemsOnMap();
                    btn.state('detoggled');
                    infoboxUpdate();
                }
            }, {
                icon: wifiClientsIcon,
                stateName: 'detoggled',
                title: 'Wifi Clients',
                onClick: function (btn) {
                    var index = findIndexOfView("WifiClients");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();

                        btn.state('toggled');
                        btn.button.style.backgroundColor = 'white';
                        infoboxUpdate();
                    }
                }
            }
        ],
        position: 'topright'
    }).addTo(geoMap);

    var toggleOccupantsButton = L.easyButton({
        id: 'easy-button',
        states: [
            {
                icon: occupantsIcon,
                title: 'Occupants',
                stateName: 'toggled',
                onClick: function (btn) {
                    if (ActiveViews.length === activeViewsMax)
                        ActiveViews[0].button.button.click();
                    var occupantsObj = {
                        name: "Occupants",
                        color: OccupantsColor,
                        icon: occupantsIcon,
                        max: 'MaxOccupants',
                        value: 'Occupants',
                        average: "AverageOccupants",
                        maxObserved: "MaxObservedOccupants",
                        minObservedTemperature: "MinObservedOccupants",
                        button: toggleOccupantsButton
                    };
                    btn.button.style.backgroundColor = OccupantsColor;
                    ActiveViews.push(occupantsObj);
                    reDrawItemsOnMap();
                    btn.state('detoggled');
                    infoboxUpdate();
                }
            }, {
                icon: occupantsIcon,
                stateName: 'detoggled',
                title: 'Occupants',
                onClick: function (btn) {
                    var index = findIndexOfView("Occupants");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();

                        btn.button.style.backgroundColor = 'white';
                        btn.state('toggled');
                        infoboxUpdate();
                    }
                }
            }
        ],
        position: 'topright'
    }).addTo(geoMap);

    var toggleTotalConsumptionButton = L.easyButton({
        id: 'easy-button',
        states: [
            {
                icon: totalConsumptionIcon,
                title: 'Total Power Consumption',
                stateName: 'toggled',
                onClick: function (btn) {
                    if (ActiveViews.length === activeViewsMax)
                        ActiveViews[0].button.button.click();
                    var totalPowerObj = {
                        name: "TotalPowerConsumption",
                        color: TotalPowerConsumptionColor,
                        icon: totalConsumptionIcon,
                        max: 'MaxTotalPowerConsumption',
                        value: 'TotalPowerConsumption',
                        min: "MinTotalPowerConsumption",
                        average: "AverageTotalPowerConsumption",
                        maxObserved: "MaxObservedTotalPowerConsumption",
                        minObservedTemperature: "MinObservedTotalPowerConsumption",
                        button: toggleTotalConsumptionButton
                    };
                    btn.button.style.backgroundColor = TotalPowerConsumptionColor; //'#e74c3c'
                    ActiveViews.push(totalPowerObj);
                    reDrawItemsOnMap();
                    infoboxUpdate();
                    btn.state('detoggled');
                }
            }, {
                icon: totalConsumptionIcon,
                title: 'Total Power Consumption',
                stateName: 'detoggled',
                onClick: function (btn) {
                    var index = findIndexOfView("TotalPowerConsumption");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();
                        btn.button.style.backgroundColor = 'white';
                        btn.state('toggled');
                        infoboxUpdate();
                    }
                }
            }
        ],
        position: 'topright'
    }).addTo(geoMap);

    var toggleHardwareConsumptionButton = L.easyButton({
        id: 'easy-button',
        states: [
            {
                icon: hardwareConsumptionIcon,
                title: 'Hardware Power Consumption',
                stateName: 'toggled',
                onClick: function (btn) {
                    if (ActiveViews.length === activeViewsMax)
                        ActiveViews[0].button.button.click();

                    var hardwareConsumptionObj = {
                        name: "HardwareConsumption",
                        color: HardwarePowerConsumptionColor,
                        icon: hardwareConsumptionIcon,
                        max: 'MaxHardwareConsumption',
                        value: 'HardwareConsumption',
                        min: "MinHardwareConsumption",
                        average: "AverageHardwareConsumption",
                        maxObserved: "MaxObservedHardwareConsumption",
                        minObservedTemperature: "MinObservedHardwareConsumption",
                        button: toggleHardwareConsumptionButton
                    };
                    btn.button.style.backgroundColor = HardwarePowerConsumptionColor; //'#f83e2d'
                    ActiveViews.push(hardwareConsumptionObj);
                    reDrawItemsOnMap();
                    btn.state('detoggled');
                    infoboxUpdate();
                }
            }, {
                icon: hardwareConsumptionIcon,
                title: 'Hardware Power Consumption',
                stateName: 'detoggled',
                onClick: function (btn) {
                    var index = findIndexOfView("HardwareConsumption");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();

                        btn.button.style.backgroundColor = 'white';
                        btn.state('toggled');
                        infoboxUpdate();
                    }
                }
            }
        ],
        position: 'topright'
    }).addTo(geoMap);;

    var toggleLightConsumptionButton = L.easyButton({
        id: 'easy-button',
        states: [
            {
                icon: lightConsumptionIcon,
                title: 'Light Power Consumption',
                stateName: 'toggled',
                onClick: function (btn) {
                    if (ActiveViews.length === activeViewsMax)
                        ActiveViews[0].button.button.click();

                    var lightConsumptionObj = {
                        name: "LightConsumption",
                        color: LightPowerConsumptionColor,
                        icon: lightConsumptionIcon,
                        max: 'MaxLightConsumption',
                        value: 'LightConsumption',
                        min: "MinLightConsumption",
                        average: "AverageLightConsumption",
                        maxObserved: "MaxObservedLightConsumption",
                        minObservedTemperature: "MinObservedLightConsumption",
                        button: toggleLightConsumptionButton
                    };
                    btn.button.style.backgroundColor = LightPowerConsumptionColor; //'#f83e2d'
                    ActiveViews.push(lightConsumptionObj);
                    reDrawItemsOnMap();
                    btn.state('detoggled');
                    infoboxUpdate();
                }
            }, {
                icon: lightConsumptionIcon,
                title: 'Light Power Consumption',
                stateName: 'detoggled',
                onClick: function (btn) {
                    var index = findIndexOfView("LightConsumption");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();

                        btn.button.style.backgroundColor = 'white';
                        btn.state('toggled');
                        infoboxUpdate();
                    }
                }
            }
        ],
        position: 'topright'
    }).addTo(geoMap);;

    var toggleVentilationConsumptionButton = L.easyButton({
        id: 'easy-button',
        states: [
            {
                icon: ventilationConsumptonIcon,
                title: 'Ventilation Power Consumption',
                stateName: 'toggled',
                onClick: function (btn) {
                    if (ActiveViews.length === activeViewsMax)
                        ActiveViews[0].button.button.click();
                    var ventilationConsumptionObj = {
                        name: "VentilationConsumption",
                        color: VentilationPowerConsumptionColor,
                        icon: ventilationConsumptonIcon,
                        max: 'MaxVentilationConsumption',
                        value: 'VentilationConsumption',
                        min: "MinVentilationConsumption",
                        average: "AverageVentilationConsumption",
                        maxObserved: "MaxObservedVentilationConsumption",
                        minObservedTemperature: "MinObservedVentilationConsumption",
                        button: toggleVentilationConsumptionButton
                    };
                    btn.button.style.backgroundColor = VentilationPowerConsumptionColor; //'#d15258'
                    ActiveViews.push(ventilationConsumptionObj);
                    reDrawItemsOnMap();
                    btn.state('detoggled');
                    infoboxUpdate();
                }
            }, {
                icon: ventilationConsumptonIcon,
                stateName: 'detoggled',
                title: 'Ventilation Power Consumption',
                onClick: function (btn) {
                    var index = findIndexOfView("VentilationConsumption");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();

                        btn.button.style.backgroundColor = 'white';
                        btn.state('toggled');
                        infoboxUpdate();
                    }
                }
            }
        ],
        position: 'topright'
    }).addTo(geoMap);;

    var toggleOtherConsumptionButton = L.easyButton({
        id: 'easy-button',
        states: [
            {
                icon: otherConsumptionIcon,
                title: 'Other Power Consumption',
                stateName: 'toggled',
                onClick: function (btn) {
                    if (ActiveViews.length === activeViewsMax)
                        ActiveViews[0].button.button.click();
                    var otherConsumptionObj = {
                        name: "OtherConsumption",
                        color: OtherPowerConsumptionColor,
                        icon: otherConsumptionIcon,
                        max: 'MaxOtherConsumption',
                        value: 'OtherConsumption',
                        min: "MinOtherConsumption",
                        average: "AverageOtherConsumption",
                        maxObserved: "MaxObservedOtherConsumption",
                        minObservedTemperature: "MinObservedOtherConsumption",
                        button: toggleOtherConsumptionButton
                    };
                    btn.button.style.backgroundColor = OtherPowerConsumptionColor; //'#ff8289'
                    ActiveViews.push(otherConsumptionObj);
                    reDrawItemsOnMap();
                    btn.state('detoggled');
                    infoboxUpdate();
                }
            }, {
                icon: otherConsumptionIcon,
                title: 'Other Power Consumption',
                stateName: 'detoggled',
                onClick: function (btn) {
                    var index = findIndexOfView("OtherConsumption");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();

                        btn.button.style.backgroundColor = 'white';
                        btn.state('toggled');
                        infoboxUpdate();
                    }
                }
            }
        ],
        position: 'topright'
    }).addTo(geoMap);;

    var toggleWaterConsumptionButton = L.easyButton({
        id: 'easy-button',
        states: [
            {
                icon: waterConsumptionIcon,
                title: 'Water Consumption',
                stateName: 'toggled',
                onClick: function (btn) {
                    var waterConsumptionObj = {
                        name: "WaterConsumption",
                        color: '#8c8c8c',
                        icon: waterConsumptionIcon,
                        value: 'WaterConsumption',
                        average: "AverageWaterConsumption",
                        maxObserved: "MaxObservedWaterConsumption",
                        minObservedTemperature: "MinObservedWaterConsumption",
                        button: toggleWaterConsumptionButton
                    };
                    btn.button.style.backgroundColor = '#8c8c8c'; //#3399cc
                    ActiveFloorViews.push(waterConsumptionObj);
                    reDrawItemsOnMap();
                    btn.state('detoggled');
                    infoboxUpdate();
                }
            }, {
                icon: waterConsumptionIcon,
                stateName: 'detoggled',
                title: 'Water Consumption',
                onClick: function (btn) {
                    var index = findIndexOfFloorView("WaterConsumption");
                    if (index !== notContained) {
                        ActiveFloorViews.splice(index, 1);
                        reDrawItemsOnMap();
                        btn.button.style.backgroundColor = 'white';
                        btn.state('toggled');
                        infoboxUpdate();
                    }
                }
            }
        ],
        position: 'topright'
    }).addTo(geoMap);
}

function reDrawItemsOnMap() {
    drawLegend();
    splitRoomsIntoBarchart();
}

function findIndexOfView(name) {
    for (var i = 0; i < ActiveViews.length; i++) {
        if (ActiveViews[i].name === name) {
            return i;
        }
    }
    return -1;
}

function findIndexOfFloorView(name) {
    for (var i = 0; i < ActiveFloorViews.length; i++) {
        if (ActiveFloorViews[i].name === name) {
            return i;
        }
    }
    return -1;
}

function isMaxViewsActive() {
    if (ActiveViews.length < activeViewsMax) {
        return true;

    } else {
        return false;

    }
}