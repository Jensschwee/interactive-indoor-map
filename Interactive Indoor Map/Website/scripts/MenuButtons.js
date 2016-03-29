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

    L.easyButton('&#45;&#49;', function () {
        if (currentFloorLevel !== -1) {
            currentFloorLevel = -1;
            resetSelectedRooms();
            getRoomsAndDrawRooms();
        }
        drawFloorInfoBox();
    }, { position: 'bottomleft' }).addTo(geoMap);

    L.easyButton('&#48;', function () {
        if (currentFloorLevel !== 0) {
            currentFloorLevel = 0;
            resetSelectedRooms();
            getRoomsAndDrawRooms();
        }
        drawFloorInfoBox();

    }, { position: 'bottomleft' }).addTo(geoMap);
    L.easyButton('&#49;', function () {
        if (currentFloorLevel !== 1) {
            currentFloorLevel = 1;
            resetSelectedRooms();
            getRoomsAndDrawRooms();
        }
        drawFloorInfoBox();
    }, { position: 'bottomleft' }).addTo(geoMap);

    L.easyButton('&#50;', function () {
        drawFloorInfoBox();
        if (currentFloorLevel !== 2) {
            currentFloorLevel = 2;
            resetSelectedRooms();
            getRoomsAndDrawRooms();
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

    var notContained = -1;

    var toggleTempButton = L.easyButton({
        states: [
            {
                icon: temperatureIcon,
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var temperatureObj = {
                            name: "Temperature",
                            color: '#8ab1c4',
                            icon: 'Images/temperatureIcon.png',
                            max: 'TemperatureMax',
                            value: 'Temperature',
                            min: "TemperatureMin",
                        };
                        btn.button.style.backgroundColor = '#8ab1c4';
                        ActiveViews.push(temperatureObj);
                        reDrawItemsOnMap();
                    }

                    btn.state('detoggled');
                }
            }, {
                icon: temperatureIcon,
                stateName: 'detoggled',
                onClick: function (btn, map) {
                    var index = findIndexOfView("Temperature");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();
                    }
                    btn.button.style.backgroundColor = 'white';
                    btn.state('toggled');
                }
            }
        ]
    });

    toggleTempButton.options.position = 'topright';
    toggleTempButton.addTo(geoMap);

    //L.easyButton(temperatureIcon, function () {
    //    var index = findIndexOfView("Temperature");
    //    if (index === -1) { //-1 should have a final name that explains what it is
    //        if (ActiveViews.length < 4) {
    //            var temperatureObj = {
    //                name: "Temperature",
    //                color: '#8ab1c4',
    //                icon: 'Images/temperatureIcon.png',
    //                max: 'TemperatureMax',
    //                value: 'Temperature',
    //                min: "TemperatureMin"
    //            };
    //            ActiveViews.push(temperatureObj);
    //            reDrawItemsOnMap();
    //        }
    //    } else {
    //        ActiveViews.splice(index, 1);
    //        reDrawItemsOnMap();
    //    }

    //}, { position: 'topright' }).addTo(geoMap);

    var toggleCO2Button = L.easyButton({
        states: [
            {
                icon: co2Icon,
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var co2Obj = {
                            name: "CO2",
                            color: '#c7b7ea',
                            icon: 'Images/co2Icon.png',
                            max: 'CO2Max',
                            value: 'CO2',
                            min: "CO2Min"
                        };
                        btn.button.style.backgroundColor = '#c7b7ea';
                        ActiveViews.push(co2Obj);
                        reDrawItemsOnMap();
                    }

                    btn.state('detoggled');
                }
            }, {
                icon: co2Icon,
                stateName: 'detoggled',
                onClick: function (btn, map) {
                    var index = findIndexOfView("CO2");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();
                    }
                    btn.button.style.backgroundColor = 'white';
                    btn.state('toggled');
                }
            }
        ]
    });
    
    toggleCO2Button.options.position = 'topright';
    toggleCO2Button.addTo(geoMap);

    //L.easyButton(co2Icon, function () {
    //    var index = findIndexOfView("CO2");
    //    if (index === -1) {
    //        if (ActiveViews.length < 4) {
    //            var co2Obj = {
    //                name: "CO2",
    //                color: '#c7b7ea',
    //                icon: 'Images/co2Icon.png',
    //                max: 'CO2Max',
    //                value: 'CO2',
    //                min: "CO2Min"
    //            };
    //            ActiveViews.push(co2Obj);
    //            reDrawItemsOnMap();
    //        }
    //    } else {
    //        ActiveViews.splice(index, 1);
    //        reDrawItemsOnMap();
    //    }

    //}, { position: 'topright' }).addTo(geoMap);

    var toggleLightButton = L.easyButton({
        states: [
            {
                icon: lightIcon,
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var co2Obj = {
                            name: "Lumen",
                            color: '#ffe11d',
                            icon: 'Images/lightIcon.png',
                            value: 'Lumen',
                            max: 'LumenMax'
                        };
                        btn.button.style.backgroundColor = '#ffe11d';
                        ActiveViews.push(co2Obj);
                        reDrawItemsOnMap();
                    }

                    btn.state('detoggled');
                }
            }, {
                icon: lightIcon,
                stateName: 'detoggled',
                onClick: function (btn, map) {
                    var index = findIndexOfView("Lumen");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();
                    }
                    btn.button.style.backgroundColor = 'white';
                    btn.state('toggled');
                }
            }
        ]
    });

    toggleLightButton.options.position = 'topright';
    toggleLightButton.addTo(geoMap);

    //L.easyButton(lightIcon, function () {
    //    var index = findIndexOfView("Lumen");
    //    if (index === -1) {
    //        if (ActiveViews.length < 4) {
    //            var lightObj = {
    //                name: "Lumen",
    //                color: '#ffe11d',
    //                icon: 'Images/lightIcon.png',
    //                value: 'Lumen',
    //                max: 'LumenMax'
    //            };
    //            ActiveViews.push(lightObj);
    //            reDrawItemsOnMap();
    //        }
    //    } else {
    //        ActiveViews.splice(index, 1);
    //        reDrawItemsOnMap();
    //    }
    //}, { position: 'topright' }).addTo(geoMap);

    var toggleTotalConsumptionButton = L.easyButton({
        states: [
            {
                icon: totalConsumptionIcon,
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var totalPowerObj = {
                            name: "TotalPowerConsumption",
                            color: '#e74c3c',
                            icon: 'Images/totalPowerIcon.png',
                            max: 'TotalPowerConsumptionMax',
                            value: 'TotalPowerConsumption',
                            min: "TotalPowerConsumptionMin"
                        };
                        btn.button.style.backgroundColor = '#e74c3c';
                        ActiveViews.push(totalPowerObj);
                        reDrawItemsOnMap();
                    }

                    btn.state('detoggled');
                }
            }, {
                icon: totalConsumptionIcon,
                stateName: 'detoggled',
                onClick: function (btn, map) {
                    var index = findIndexOfView("TotalPowerConsumption");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();
                    }
                    btn.button.style.backgroundColor = 'white';
                    btn.state('toggled');
                }
            }
        ]
    });

    toggleTotalConsumptionButton.options.position = 'topright';
    toggleTotalConsumptionButton.addTo(geoMap);

    //L.easyButton(totalConsumptionIcon, function () {
    //    var index = findIndexOfView("TotalPowerConsumption");
    //    if (index === -1) {
    //        if (ActiveViews.length < 4) {
    //            var totalPowerObj = {
    //                name: "TotalPowerConsumption",
    //                color: '#e74c3c',
    //                icon: 'Images/totalPowerIcon.png',
    //                max: 'TotalPowerConsumptionMax',
    //                value: 'TotalPowerConsumption',
    //                min: "TotalPowerConsumptionMin"
    //            };
    //            ActiveViews.push(totalPowerObj);
    //            reDrawItemsOnMap();
    //        }
    //    } else {
    //        ActiveViews.splice(index, 1);
    //        reDrawItemsOnMap();
    //    }
    //}, { position: 'topright' }).addTo(geoMap);

    var toggleHardwareConsumptionButton = L.easyButton({
        states: [
            {
                icon: hardwareConsumptionIcon,
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var hardwareConsumptionObj = {
                            name: "HardwareConsumption",
                            color: '#f83e2d',
                            icon: 'Images/hardwarePowerIcon.png',
                            max: 'HardwareConsumptionMax',
                            value: 'HardwareConsumption',
                            min: "HardwareConsumptionMin"
                        };
                        btn.button.style.backgroundColor = '#f83e2d';
                        ActiveViews.push(hardwareConsumptionObj);
                        reDrawItemsOnMap();
                    }

                    btn.state('detoggled');
                }
            }, {
                icon: hardwareConsumptionIcon,
                stateName: 'detoggled',
                onClick: function (btn, map) {
                    var index = findIndexOfView("HardwareConsumption");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();
                    }
                    btn.button.style.backgroundColor = 'white';
                    btn.state('toggled');
                }
            }
        ]
    });

    toggleHardwareConsumptionButton.options.position = 'topright';
    toggleHardwareConsumptionButton.addTo(geoMap);

    //L.easyButton(hardwareConsumptionIcon, function () {

    //    var index = findIndexOfView("HardwareConsumption");
    //    if (index === -1) {
    //        if (ActiveViews.length < 4) {
    //            var hardwareObj = {
    //                name: "HardwareConsumption",
    //                color: '#f83e2d',
    //                icon: 'Images/hardwarePowerIcon.png',
    //                max: 'HardwareConsumptionMax',
    //                value: 'HardwareConsumption',
    //                min: "HardwareConsumptionMin"
    //            };
    //            ActiveViews.push(hardwareObj);
    //            reDrawItemsOnMap();
    //        }
    //    } else {
    //        ActiveViews.splice(index, 1);
    //        reDrawItemsOnMap();
    //    }
    //}, { position: 'topright' }).addTo(geoMap);

    var toggleLightConsumptionButton = L.easyButton({
        states: [
            {
                icon: lightConsumptionIcon,
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var lightConsumptionObj = {
                            name: "LightConsumption",
                            color: '#fe4e35',
                            icon: 'Images/lightPowerIcon.png',
                            max: 'LightConsumptionMax',
                            value: 'LightConsumption',
                            min: "LightConsumptionMin"
                        };
                        btn.button.style.backgroundColor = '#f83e2d';
                        ActiveViews.push(lightConsumptionObj);
                        reDrawItemsOnMap();
                    }

                    btn.state('detoggled');
                }
            }, {
                icon: lightConsumptionIcon,
                stateName: 'detoggled',
                onClick: function (btn, map) {
                    var index = findIndexOfView("LightConsumption");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();
                    }
                    btn.button.style.backgroundColor = 'white';
                    btn.state('toggled');
                }
            }
        ]
    });

    toggleLightConsumptionButton.options.position = 'topright';
    toggleLightConsumptionButton.addTo(geoMap);

    //L.easyButton(lightConsumptionIcon, function () {

    //    var index = findIndexOfView("LightConsumption");
    //    if (index === -1) {
    //        if (ActiveViews.length < 4) {
    //            var lightPowerObj = {
    //                name: "LightConsumption",
    //                color: '#fe4e35',
    //                icon: 'Images/lightPowerIcon.png',
    //                max: 'LightConsumptionMax',
    //                value: 'LightConsumption',
    //                min: "LightConsumptionMin"
    //            };
    //            ActiveViews.push(lightPowerObj);
    //            reDrawItemsOnMap();
    //        }
    //    } else {
    //        ActiveViews.splice(index, 1);
    //        reDrawItemsOnMap();
    //    }
    //}, { position: 'topright' }).addTo(geoMap);

    var toggleVentilationConsumptionButton = L.easyButton({
        states: [
            {
                icon: ventilationConsumptonIcon,
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var ventilationConsumptionObj = {
                            name: "VentilationConsumption",
                            color: '#d15258',
                            icon: 'Images/ventilationPowerIcon.png',
                            max: 'VentilationConsumptionMax',
                            value: 'VentilationConsumption',
                            min: "VentilationConsumptionMin"
                        };
                        btn.button.style.backgroundColor = '#d15258';
                        ActiveViews.push(ventilationConsumptionObj);
                        reDrawItemsOnMap();
                    }

                    btn.state('detoggled');
                }
            }, {
                icon: ventilationConsumptonIcon,
                stateName: 'detoggled',
                onClick: function (btn, map) {
                    var index = findIndexOfView("VentilationConsumption");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();
                    }
                    btn.button.style.backgroundColor = 'white';
                    btn.state('toggled');
                }
            }
        ]
    });

    toggleVentilationConsumptionButton.options.position = 'topright';
    toggleVentilationConsumptionButton.addTo(geoMap);

    //L.easyButton(ventilationConsumptonIcon, function () {
    //    var index = findIndexOfView("VentilationConsumption");
    //    if (index === -1) {
    //        if (ActiveViews.length < 4) {
    //            var ventilationPowerObj = {
    //                name: "VentilationConsumption",
    //                color: '#d15258',
    //                icon: 'Images/ventilationPowerIcon.png',
    //                max: 'VentilationConsumptionMax',
    //                value: 'VentilationConsumption',
    //                min: "VentilationConsumptionMin"
    //            };
    //            ActiveViews.push(ventilationPowerObj);
    //            reDrawItemsOnMap();
    //        }
    //    } else {
    //        ActiveViews.splice(index, 1);
    //        reDrawItemsOnMap();
    //    }
    //}, { position: 'topright' }).addTo(geoMap);

    var toggleOtherConsumptionButton = L.easyButton({
        states: [
            {
                icon: otherConsumptionIcon,
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var otherConsumptionObj = {
                            name: "OtherConsumption",
                            color: '#ff8289',
                            icon: 'Images/otherPowerIcon.png',
                            max: 'OtherConsumptionMax',
                            value: 'OtherConsumption',
                            min: "OtherConsumptionMin"
                        };
                        btn.button.style.backgroundColor = '#ff8289';
                        ActiveViews.push(otherConsumptionObj);
                        reDrawItemsOnMap();
                    }

                    btn.state('detoggled');
                }
            }, {
                icon: otherConsumptionIcon,
                stateName: 'detoggled',
                onClick: function (btn, map) {
                    var index = findIndexOfView("OtherConsumption");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();
                    }
                    btn.button.style.backgroundColor = 'white';
                    btn.state('toggled');
                }
            }
        ]
    });

    toggleOtherConsumptionButton.options.position = 'topright';
    toggleOtherConsumptionButton.addTo(geoMap);

    //L.easyButton(otherConsumptionIcon, function () {
    //    var index = findIndexOfView("OtherConsumption");
    //    if (index === -1) {
    //        if (ActiveViews.length < 4) {
    //            var otherPowerObj = {
    //                name: "OtherConsumption",
    //                color: '#ff8289',
    //                icon: 'Images/otherPowerIcon.png',
    //                max: 'OtherConsumptionMax',
    //                value: 'OtherConsumption',
    //                min: "OtherConsumptionMin"
    //            };
    //            ActiveViews.push(otherPowerObj);
    //            reDrawItemsOnMap();
    //        }
    //    } else {
    //        ActiveViews.splice(index, 1);
    //        reDrawItemsOnMap();
    //    }
    //}, { position: 'topright' }).addTo(geoMap);

    var toggleMotionButton = L.easyButton({
        states: [
            {
                icon: motionIcon,
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var motionObj = {
                            name: "Motion",
                            color: '#b2d649',
                            icon: 'Images/motionIcon.png',
                            value: 'Motion'
                        };
                        btn.button.style.backgroundColor = '#b2d649';
                        ActiveViews.push(motionObj);
                        reDrawItemsOnMap();
                    }

                    btn.state('detoggled');
                }
            }, {
                icon: motionIcon,
                stateName: 'detoggled',
                onClick: function (btn, map) {
                    var index = findIndexOfView("Motion");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();
                    }
                    btn.button.style.backgroundColor = 'white';
                    btn.state('toggled');
                }
            }
        ]
    });

    toggleMotionButton.options.position = 'topright';
    toggleMotionButton.addTo(geoMap);

    //L.easyButton(motionIcon, function () {
    //    var index = findIndexOfView("Motion");
    //    if (index === -1) {
    //        if (ActiveViews.length < 4) {
    //            var otherPowerObj = {
    //                name: "Motion",
    //                color: '#b2d649',
    //                icon: 'Images/motionIcon.png',
    //                value: 'Motion'
    //            };
    //            ActiveViews.push(otherPowerObj);
    //            reDrawItemsOnMap();
    //        }
    //    } else {
    //        ActiveViews.splice(index, 1);
    //        reDrawItemsOnMap();
    //    }
    //}, { position: 'topright' }).addTo(geoMap);

    var toggleOccupantsButton = L.easyButton({
        states: [
            {
                icon: occupantsIcon,
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var occupantsObj = {
                            name: "Occupants",
                            color: '#2ecc71',
                            icon: 'Images/occupantsIcon.png',
                            max: 'OccupantsMax',
                            value: 'Occupants'
                        };
                        btn.button.style.backgroundColor = '#2ecc71';
                        ActiveViews.push(occupantsObj);
                        reDrawItemsOnMap();
                    }

                    btn.state('detoggled');
                }
            }, {
                icon: occupantsIcon,
                stateName: 'detoggled',
                onClick: function (btn, map) {
                    var index = findIndexOfView("Occupants");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();
                    }
                    btn.button.style.backgroundColor = 'white';
                    btn.state('toggled');
                }
            }
        ]
    });

    toggleOccupantsButton.options.position = 'topright';
    toggleOccupantsButton.addTo(geoMap);

    //L.easyButton(occupantsIcon, function () {

    //    var index = findIndexOfView("Occupants");
    //    if (index === -1) {
    //        if (ActiveViews.length < 4) {
    //            var occupantsObj = {
    //                name: "Occupants",
    //                color: '#2ecc71',
    //                icon: 'Images/occupantsIcon.png',
    //                max: 'OccupantsMax',
    //                value: 'Occupants'
    //            };
    //            ActiveViews.push(occupantsObj);
    //            reDrawItemsOnMap();
    //        }
    //    } else {
    //        ActiveViews.splice(index, 1);
    //        reDrawItemsOnMap();
    //    }
    //}, { position: 'topright' }).addTo(geoMap);

    var toggleWifiClientsButton = L.easyButton({
        states: [
            {
                icon: wifiClientsIcon,
                stateName: 'toggled',
                onClick: function (btn, map) {
                    if (ActiveViews.length < 4) {
                        var wifiClientsObj = {
                            name: "WifiClients",
                            color: '#83bd1a',
                            icon: 'Images/wifiIcon.png',
                            max: 'WifiClientsMax',
                            value: 'WifiClients'
                        };
                        btn.button.style.backgroundColor = '#83bd1a';
                        ActiveViews.push(wifiClientsObj);
                        reDrawItemsOnMap();
                    }

                    btn.state('detoggled');
                }
            }, {
                icon: wifiClientsIcon,
                stateName: 'detoggled',
                onClick: function (btn, map) {
                    var index = findIndexOfView("WifiClients");
                    if (index !== notContained) {
                        ActiveViews.splice(index, 1);
                        reDrawItemsOnMap();
                    }
                    btn.button.style.backgroundColor = 'white';
                    btn.state('toggled');
                }
            }
        ]
    });

    toggleWifiClientsButton.options.position = 'topright';
    toggleWifiClientsButton.addTo(geoMap);

    //L.easyButton(wifiClientsIcon, function () {
    //    var index = findIndexOfView("WifiClients");
    //    if (index === -1) {
    //        if (ActiveViews.length < 4) {
    //            var wifiClientsObj = {
    //                name: "WifiClients",
    //                color: '#83bd1a',
    //                icon: 'Images/wifiIcon.png',
    //                max: 'WifiClientsMax',
    //                value: 'WifiClients'
    //            };
    //            ActiveViews.push(wifiClientsObj);
    //            reDrawItemsOnMap();
    //        }
    //    } else {
    //        ActiveViews.splice(index, 1);
    //        reDrawItemsOnMap();
    //    }
    //}, { position: 'topright' }).addTo(geoMap);
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