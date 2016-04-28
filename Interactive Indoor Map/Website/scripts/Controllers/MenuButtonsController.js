﻿var buildingButton;
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

    /*var cellarButton = L.easyButton({
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
        position: 'bottomright',
        states: [{
            stateName: 'None',
            icon: '&#80;', //P
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
                buildingButton.button.style.backgroundColor = 'white';
            }
        }]
    }).addTo(geoMap);

    var groundFloorButton = L.easyButton({
        position: 'bottomright',
        states: [{
            stateName: 'None',
            icon: '&#71;', //G
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
                buildingButton.button.style.backgroundColor = 'white';
            }
        }]
    }).addTo(geoMap);

    groundFloorButton.button.style.backgroundColor = '#8c8c8c';

    var firstFloorButton = L.easyButton({
        position: 'bottomright',
        states: [{
            stateName: 'None',
            icon: '&#49;', //1
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
                buildingButton.button.style.backgroundColor = 'white';
            }
        }]
    }).addTo(geoMap);

    var buildingIcon = createIconForButton("Images/buildingIcon.png");

    buildingButton = L.easyButton({
        position: 'bottomright',
        states: [{
            stateName: 'None',
            icon: buildingIcon,
            title: 'Building',
            onClick: function (btn) {
                drawBuildingInfoBox();
                btn.button.style.backgroundColor = '#8c8c8c';

            }
        }]
    }).addTo(geoMap);

    buildingButton.button.style.backgroundColor = '#8c8c8c';

    var waterConsumptionIcon = createIconForButton("Images/waterConsumptionIcon.png");

    var toggleWaterConsumptionButton = L.easyButton({
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
        position: 'bottomright'
    }).addTo(geoMap);
}

function createIconForButton(imageSrc) {
    var height = 25;
    var width = 25;
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


    var toggleTempButton = L.easyButton({
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
        states: [
            {
                icon: lightIcon,
                title: 'Lumen',
                stateName: 'toggled',
                onClick: function (btn) {
                    if (ActiveViews.length === activeViewsMax)
                        ActiveViews[0].button.button.click();
                    var co2Obj = {
                        name: "Lumen",
                        color: LightColor,
                        icon: lightIcon,
                        value: 'Lumen',
                        max: 'MaxLumen',
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
                title: 'Lumen',
                stateName: 'detoggled',
                onClick: function (btn) {
                    var index = findIndexOfView("Lumen");
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