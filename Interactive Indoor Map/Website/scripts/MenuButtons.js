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

    L.easyButton({
        position: 'bottomright',
        states: [{
            stateName: 'None',
            icon: '&#45;&#49;',
            title: 'Cellar',
            onClick: function () {
                if (currentFloorLevel !== -1) {
                    currentFloorLevel = -1;
                    changeFloor();
                }
                drawFloorInfoBox();
            }
        }]
    }).addTo(geoMap);

    L.easyButton({
        position: 'bottomright',
        states: [{
            stateName: 'None',
            icon: '&#48;',
            title: 'Parterre',
            onClick: function () {
                if (currentFloorLevel !== 0) {
                    currentFloorLevel = 0;
                    changeFloor();
                }
                drawFloorInfoBox();
            }
        }]
    }).addTo(geoMap);

    L.easyButton({
        position: 'bottomright',
        states: [{
            stateName: 'None',
            icon: '&#49;',
            title: 'Ground Floor',
            onClick: function () {
                if (currentFloorLevel !== 1) {
                    currentFloorLevel = 1;
                    changeFloor();
                }
                drawFloorInfoBox();
            }
        }]
    }).addTo(geoMap);

    L.easyButton({
        position: 'bottomright',
        states: [{
            stateName: 'None',
            icon: '&#50;',
            title: 'First Floor',
            onClick: function () {
                if (currentFloorLevel !== 2) {
                    currentFloorLevel = 2;
                    changeFloor();
                }
                drawFloorInfoBox();
            }
        }]
    }).addTo(geoMap);

    var buildingIcon = createIconForButton("Images/buildingIcon.png");

    L.easyButton({
        position: 'bottomright',
        states: [{
            stateName: 'None',
            icon: buildingIcon,
            title: 'Building',
            onClick: function () {
                drawBuildingInfoBox();
            }
        }]
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

    var notContained = -1;

    var toggleTempButton = L.easyButton({
        states: [
            {
                icon: temperatureIcon,
                title: 'Temperature',
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var temperatureObj = {
                            name: "Temperature",
                            color: '#8ab1c4',
                            icon: temperatureIcon,
                            max: 'TemperatureMax',
                            value: 'Temperature',
                            min: "TemperatureMin",
                            button: toggleTempButton
                        };
                        btn.button.style.backgroundColor = '#8ab1c4';
                        ActiveViews.push(temperatureObj);
                        reDrawItemsOnMap();
                        btn.state('detoggled');
                        infoboxUpdate();
                    }
                }
            }, {
                icon: temperatureIcon,
                stateName: 'detoggled',
                title: 'Temperature',
                onClick: function (btn, map) {
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
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var co2Obj = {
                            name: "CO2",
                            color: '#c7b7ea',
                            icon: co2Icon,
                            max: 'CO2Max',
                            value: 'CO2',
                            min: "CO2Min",
                            button: toggleCO2Button
                        };
                        btn.button.style.backgroundColor = '#c7b7ea';
                        ActiveViews.push(co2Obj);
                        reDrawItemsOnMap();
                        btn.state('detoggled');
                        infoboxUpdate();
                    }
                }
            }, {
                icon: co2Icon,
                stateName: 'detoggled',
                title: 'CO2',
                onClick: function (btn, map) {
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
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var co2Obj = {
                            name: "Lumen",
                            color: '#ffe11d',
                            icon: lightIcon,
                            value: 'Lumen',
                            max: 'LumenMax',
                            button: toggleLightButton
                        };
                        btn.button.style.backgroundColor = '#ffe11d';
                        ActiveViews.push(co2Obj);
                        reDrawItemsOnMap();
                        btn.state('detoggled');
                        infoboxUpdate();
                    }
                }
            }, {
                icon: lightIcon,
                title: 'Lumen',
                stateName: 'detoggled',
                onClick: function (btn, map) {
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

    var toggleTotalConsumptionButton = L.easyButton({
        states: [
            {
                icon: totalConsumptionIcon,
                title: 'Total Power Consumption',
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var totalPowerObj = {
                            name: "TotalPowerConsumption",
                            color: '#e74c3c',
                            icon: totalConsumptionIcon,
                            max: 'TotalPowerConsumptionMax',
                            value: 'TotalPowerConsumption',
                            min: "TotalPowerConsumptionMin",
                            button: toggleTotalConsumptionButton
                        };
                        btn.button.style.backgroundColor = '#e74c3c';
                        ActiveViews.push(totalPowerObj);
                        reDrawItemsOnMap();
                        infoboxUpdate();
                        btn.state('detoggled');
                    }

                }
            }, {
                icon: totalConsumptionIcon,
                title: 'Total Power Consumption',
                stateName: 'detoggled',
                onClick: function (btn, map) {
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
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var hardwareConsumptionObj = {
                            name: "HardwareConsumption",
                            color: '#f83e2d',
                            icon: hardwareConsumptionIcon,
                            max: 'HardwareConsumptionMax',
                            value: 'HardwareConsumption',
                            min: "HardwareConsumptionMin",
                            button: toggleHardwareConsumptionButton
                        };
                        btn.button.style.backgroundColor = '#f83e2d';
                        ActiveViews.push(hardwareConsumptionObj);
                        reDrawItemsOnMap();
                        btn.state('detoggled');
                        infoboxUpdate();
                    }

                }
            }, {
                icon: hardwareConsumptionIcon,
                title: 'Hardware Power Consumption',
                stateName: 'detoggled',
                onClick: function (btn, map) {
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
                onClick: function(btn, map) {
                    if (ActiveViews.length < 4) {
                        var lightConsumptionObj = {
                            name: "LightConsumption",
                            color: '#fe4e35',
                            icon: lightConsumptionIcon,
                            max: 'LightConsumptionMax',
                            value: 'LightConsumption',
                            min: "LightConsumptionMin",
                            button: toggleLightConsumptionButton
                        };
                        btn.button.style.backgroundColor = '#f83e2d';
                        ActiveViews.push(lightConsumptionObj);
                        reDrawItemsOnMap();
                        btn.state('detoggled');
                        infoboxUpdate();
                    }
                }
            }, {
                icon: lightConsumptionIcon,
                title: 'Light Power Consumption',
                stateName: 'detoggled',
                onClick: function(btn, map) {
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
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var ventilationConsumptionObj = {
                            name: "VentilationConsumption",
                            color: '#d15258',
                            icon: ventilationConsumptonIcon,
                            max: 'VentilationConsumptionMax',
                            value: 'VentilationConsumption',
                            min: "VentilationConsumptionMin",
                            button: toggleVentilationConsumptionButton
                        };
                        btn.button.style.backgroundColor = '#d15258';
                        ActiveViews.push(ventilationConsumptionObj);
                        reDrawItemsOnMap();
                        btn.state('detoggled');
                        infoboxUpdate();
                    }

                }
            }, {
                icon: ventilationConsumptonIcon,
                stateName: 'detoggled',
                title: 'Ventilation Power Consumption',
                onClick: function (btn, map) {
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
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var otherConsumptionObj = {
                            name: "OtherConsumption",
                            color: '#ff8289',
                            icon: otherConsumptionIcon,
                            max: 'OtherConsumptionMax',
                            value: 'OtherConsumption',
                            min: "OtherConsumptionMin",
                            button: toggleOtherConsumptionButton
                        };
                        btn.button.style.backgroundColor = '#ff8289';
                        ActiveViews.push(otherConsumptionObj);
                        reDrawItemsOnMap();
                        btn.state('detoggled');
                        infoboxUpdate();
                    }
                }
            }, {
                icon: otherConsumptionIcon,
                title: 'Other Power Consumption',
                stateName: 'detoggled',
                onClick: function (btn, map) {
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

    var toggleMotionButton = L.easyButton({
        states: [
            {
                icon: motionIcon,
                title: 'Motion Detection',
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var motionObj = {
                            name: "Motion",
                            color: '#b2d649',
                            icon: motionIcon,
                            value: 'Motion',
                            button: toggleMotionButton
                        };
                        btn.button.style.backgroundColor = '#b2d649';
                        ActiveViews.push(motionObj);
                        reDrawItemsOnMap();
                        btn.state('detoggled');
                        infoboxUpdate();
                    }

                }
            }, {
                icon: motionIcon,
                title: 'Motion Detection',
                stateName: 'detoggled',
                onClick: function (btn, map) {
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

    var toggleOccupantsButton = L.easyButton({
        states: [
            {
                icon: occupantsIcon,
                title: 'Occupants',
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var occupantsObj = {
                            name: "Occupants",
                            color: '#2ecc71',
                            icon: occupantsIcon,
                            max: 'OccupantsMax',
                            value: 'Occupants',
                            button: toggleOccupantsButton
                        };
                        btn.button.style.backgroundColor = '#2ecc71';
                        ActiveViews.push(occupantsObj);
                        reDrawItemsOnMap();
                        btn.state('detoggled');
                        infoboxUpdate();
                    }

                }
            }, {
                icon: occupantsIcon,
                stateName: 'detoggled',
                title: 'Occupants',
                onClick: function (btn, map) {
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

    var toggleWifiClientsButton = L.easyButton({
        states: [
            {
                icon: wifiClientsIcon,

                stateName: 'toggled',
                title: 'Wifi Clients',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var wifiClientsObj = {
                            name: "WifiClients",
                            color: '#83bd1a',
                            icon: wifiClientsIcon,
                            max: 'WifiClientsMax',
                            value: 'WifiClients',
                            button: toggleWifiClientsButton

                        };
                        btn.button.style.backgroundColor = '#83bd1a';
                        ActiveViews.push(wifiClientsObj);
                        reDrawItemsOnMap();
                        btn.state('detoggled');
                        infoboxUpdate();
                    }

                }
            }, {
                icon: wifiClientsIcon,
                stateName: 'detoggled',
                title: 'Wifi Clients',
                onClick: function (btn, map) {
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
}

function reDrawItemsOnMap() {
    drawLegend();
    drawRooms();
}

function findIndexOfView(name) {
    for (var i = 0; i < ActiveViews.length; i++) {
        if (ActiveViews[i].name === name) {
            return i;
        }
    }
    return -1;
}