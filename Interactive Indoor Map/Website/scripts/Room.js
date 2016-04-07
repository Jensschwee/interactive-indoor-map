function drawRooms(colletionOfRooms) {
    colletionOfRooms = typeof colletionOfRooms !== 'undefined' ? colletionOfRooms : colletionOfRoomsOnMap;

    var numberOfLayers = roomLayers.length;
    for (var k = 0; k < numberOfLayers; k++) {
        geoMap.removeLayer(roomLayers.pop());

    }

    //d3.select("body").selectAll("div.leaflet-overlay-pane").selectAll("svg.rooms").remove();
    var column = new Array();
    for (var j = 0; j < ActiveViews.length; j++) {
        var features = new Array();
        var jsonColumn = {
            type: "FeatureCollection",
            features: features
        };
        $.each(colletionOfRooms.features, function (index, value) {
            var coordinate = new Array();
            var coordinates = new Array();

            coordinate.push(coordinates);
            var geometry =
                {
                    type: "Polygon",
                    coordinates: coordinate
                };
            var feature = {
                type: "Feature",
                geometry: geometry,
                properties: value.properties
            }
            //bottomRightVertex
            var D = value.geometry.coordinates[0][3];
            //bottomLeftVertex
            var A = value.geometry.coordinates[0][2];

            ////topRightVertex
            var C = value.geometry.coordinates[0][0];
            ////topLeftVertex
            var B = value.geometry.coordinates[0][1];
            var minValue = 0;
            if (ActiveViews[j].hasOwnProperty("min")) {
                minValue = value.properties[ActiveViews[j].min];
            }
            var maxValue = 1;
            if (ActiveViews[j].hasOwnProperty("max")) {
                maxValue = value.properties[ActiveViews[j].max];
            }

            var sensorValue = value.properties[ActiveViews[j].value];

            var point = [];
            //Col A X
            point.push(A[0] + ((D[0] - A[0]) / ActiveViews.length) * j);
            //Col A y
            point.push(A[1] + ((D[1] - A[1]) / ActiveViews.length) * j);


            coordinates.push(point);

            point = [];
            //Col D X
            point.push(A[0] + ((D[0] - A[0]) / ActiveViews.length) * (j + 1));

            //Col D y
            point.push(A[1] + ((D[1] - A[1]) / ActiveViews.length) * (j + 1));

            coordinates.push(point);

            //calc the hight of the room
            var roomHeight = (1 - (sensorValue - minValue) / (maxValue - minValue));

            //If the room is to fill more then 100%
            if (roomHeight < 0) {
                roomHeight = 0;
            }
            //If the room is to fill less then 0%
            else if (roomHeight > 1) {
                roomHeight = 1;
            }

            point = [];
            //Col C X
            point.push(B[0] + ((C[0] - B[0]) / ActiveViews.length) * (j + 1) - ((B[0] - A[0]) * roomHeight));

            //Col C y
            point.push(B[1] + ((C[1] - B[1]) / ActiveViews.length) * (j + 1) - ((B[1] - A[1]) * roomHeight));

            coordinates.push(point);

            point = [];
            //Col B X
            point.push(B[0] + ((C[0] - B[0]) / ActiveViews.length) * (j) - ((B[0] - A[0]) * roomHeight));

            //Col B y
            point.push(B[1] + ((C[1] - B[1]) / ActiveViews.length) * (j) - ((B[1] - A[1]) * roomHeight));

            coordinates.push(point);

            coordinates.push(coordinates[0]);

            features.push(feature);

        });
        column.push(jsonColumn);
    }

    for (var i = 0; i < ActiveViews.length; i++) {
        var roomColumn = column.shift();

        roomLayers.push(L.geoJson(roomColumn, {
            style: {
                //Backgrund color
                fillColor: ActiveViews[i].color,
                //border color
                color: "black",
                //Border thickness
                opacity: "none",
                fillOpacity: "none",
                weight: "1px"
            }
        }).addTo(geoMap).bringToBack());
    }
}

function getRoomsAndDrawRoomsWithRoomOverlay() {
    function onSuccess(response) {
        colletionOfRoomsOnMap = JSON.parse(response);
        drawRoomsBackgrund(colletionOfRoomsOnMap);
        drawRooms(colletionOfRoomsOnMap);
    }
    PageMethods.DrawFloor(currentFloorLevel, onSuccess);
}

function getRoomsAndDrawRooms() {
    function onSuccess(response) {
        colletionOfRoomsOnMap = JSON.parse(response);
        drawRooms(colletionOfRoomsOnMap);
    }
    PageMethods.DrawFloor(currentFloorLevel, onSuccess);
}

function drawRoomsBackgrund(json) {
    
    if (roomBackgroundLayer != null) {
        geoMap.removeLayer(roomBackgroundLayer);
    }

    var roomOnClickEventHandler = function (feature, layer) {
        layer.on({
            click: onRoomClicked
        });
    };

    roomBackgroundLayer = L.geoJson(json, {
        style: {
            //Backgrund color
            fillColor: "#FFFFFF",
            //border color
            color: "#FFFFFF",
            //Border thickness
            weight: 5,
            opacity: 10,
            fillOpacity: 0.2
        },
        onEachFeature: roomOnClickEventHandler
    });
    var frontLayer = 1;
    roomBackgroundLayer.setZIndex(frontLayer).addTo(geoMap);
}

function changeFloor() {
    roomArray = [];
    getRoomsAndDrawRoomsWithRoomOverlay();
}

function onRoomClicked(e) {
    var layer = e.target;

    if ($.inArray(layer.feature.properties.Name, roomArray) === -1) {
        layer.setStyle({
            fillColor: "#FFFFFF",
            //border color
            weight: 5,
            color: '#8c8c8c'
        });

        if (!L.Browser.ie && !L.Browser.opera) {
            layer.bringToFront();
        }

        roomArray.push(layer.feature.properties.Name);
    } else {
        roomArray = jQuery.grep(roomArray, function (value) {
            return value != layer.feature.properties.Name;
        });

        //deseleced room
        roomBackgroundLayer.resetStyle(e.target);
        infoBox.update();
    }

    buildingButton.button.style.backgroundColor = 'white';
    drawRoomInfo();
    infoboxUpdate = function () { drawSelectedRoomInfoBox(); };
    infoboxUpdate();
}