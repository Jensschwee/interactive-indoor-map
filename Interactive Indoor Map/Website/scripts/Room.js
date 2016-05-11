function splitRoomsIntoBarchart(colletionOfRooms) {
    colletionOfRooms = typeof colletionOfRooms !== 'undefined' ? colletionOfRooms : colletionOfRoomsOnMap;

    var numberOfLayers = roomLayers.length;
    for (var k = 0; k < numberOfLayers; k++) {
        geoMap.removeLayer(roomLayers.pop());
    }
    if (linesOnMap != null) {
        geoMap.removeLayer(linesOnMap);
    }
    if (linesMinMaxOnMap != null) {
        geoMap.removeLayer(linesMinMaxOnMap);
    }

    var column = new Array();
    var jsonColumn;
    var featuresLines = new Array();
    var jsonMinMaxLines = {
        type: "FeatureCollection",
        features: featuresLines
    };
    for (var columnNumber = 0; columnNumber < ActiveViews.length; columnNumber++) {
        var features = new Array();
        jsonColumn = {
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
            var bottomRightVertex = value.geometry.coordinates[0][2];

            //bottomLeftVertex
            var bottomLeftVertex = value.geometry.coordinates[0][1];

            ////topRightVertex
            var topRightVertex = value.geometry.coordinates[0][3];

            ////topLeftVertex
            var topLeftVertex = value.geometry.coordinates[0][0];

            var minValue = 0;
            if (ActiveViews[columnNumber].hasOwnProperty("min")) {
                minValue = value.properties[ActiveViews[columnNumber].min];
            }
            var maxValue = 1;
            if (ActiveViews[columnNumber].hasOwnProperty("max")) {
                maxValue = value.properties[ActiveViews[columnNumber].max];
            }
            var sensorValue = 0;

            if (value.properties.hasOwnProperty(ActiveViews[columnNumber].value)) {
                sensorValue = value.properties[ActiveViews[columnNumber].value];
            }

            if (temporalActive) {
                sensorValue = value.properties[ActiveViews[columnNumber].average];
                drawMinMaxObservedLines(featuresLines, columnNumber, value.properties[ActiveViews[columnNumber].minObserved], value.properties[ActiveViews[columnNumber].maxObserved], minValue, maxValue, bottomRightVertex, bottomLeftVertex, topRightVertex, topLeftVertex);
            }
            var roomColumnWidthX = ((bottomRightVertex[0] - bottomLeftVertex[0]) / ActiveViews.length);
            var roomColumnWidthY = ((bottomRightVertex[1] - bottomLeftVertex[1]) / ActiveViews.length);

            var roomBottomLeftColumnOffsetX = roomColumnWidthX * columnNumber;
            var roomBottomLeftColumnOffsetY = roomColumnWidthY * columnNumber;

            var point = [];
            //Column bottomLeftVertex X
            point.push(bottomLeftVertex[0] + roomBottomLeftColumnOffsetX);
            //Column bottomLeftVertex Y
            point.push(bottomLeftVertex[1] + roomBottomLeftColumnOffsetY);

            coordinates.push(point);

            point = [];

            var roomBottomRightColumnOffsetX = roomColumnWidthX * (columnNumber+1);
            var roomBottomRightColumnOffsetY = roomColumnWidthY * (columnNumber+1);
            //Column bottomRightVertex X
            point.push(bottomLeftVertex[0] + roomBottomRightColumnOffsetX);

            //Column bottomRightVertex Y
            point.push(bottomLeftVertex[1] + roomBottomRightColumnOffsetY);

            coordinates.push(point);

            //calc the hight of the room
            var roomHeight = ((sensorValue - minValue) / (maxValue - minValue));

            //If the room is to fill more then 100%
            if (roomHeight < 0) {
                roomHeight = 0;
            }
                //If the room is to fill less then 0%
            else if (roomHeight > 1) {
                roomHeight = 1;
            }

            var roomHeightX = ((topLeftVertex[0] - bottomLeftVertex[0]) * roomHeight);
            var roomHeightY = ((topLeftVertex[1] - bottomLeftVertex[1]) * roomHeight);

            var roomTopRightColumnOffsetX = roomColumnWidthX * (columnNumber + 1);
            var roomTopRightColumnOffsetY = roomColumnWidthY * (columnNumber + 1);

            point = [];
            //Column TopRightVertex X
            point.push(bottomLeftVertex[0] + roomTopRightColumnOffsetX + roomHeightX);
            //Column TopRightVertex Y
            point.push(bottomLeftVertex[1] + roomTopRightColumnOffsetY + roomHeightY);
            coordinates.push(point);

            point = [];
            var roomTopLeftColumnOffsetX = roomColumnWidthX * columnNumber;
            var roomTopLeftColumnOffsetY = roomColumnWidthY * columnNumber;

            //Column TopLeftVertex X
            point.push(bottomLeftVertex[0] + roomTopLeftColumnOffsetX + roomHeightX);
            //Column TopLeftVertex Y
            point.push(bottomLeftVertex[1] + roomTopLeftColumnOffsetY + roomHeightY);

            coordinates.push(point);

            coordinates.push(coordinates[0]);

            features.push(feature);
        });
        column.push(jsonColumn);
    }

    //LineString
    var features2 = new Array();
    var jsonLines = {
        type: "FeatureCollection",
        features: features2
    }

    if (column.length > 0) {
        $.each(colletionOfRooms.features, function (index, value) {

            //bottomRightVertex
            var bottomRightVertex = value.geometry.coordinates[0][2];

            //bottomLeftVertex
            var bottomLeftVertex = value.geometry.coordinates[0][1];

            ////topRightVertex
            var topRightVertex = value.geometry.coordinates[0][3];

            ////topLeftVertex
            var topLeftVertex = value.geometry.coordinates[0][0];


            for (var l = 1; l < 4; l++) {
                var coordinate2 = new Array();
                var coordinates2 = new Array();

                coordinate2.push(coordinates2);
                var geometry2 =
                {
                    type: "LineString",
                    coordinates: coordinates2
                };
                var feature2 = {
                    type: "Feature",
                    geometry: geometry2
                }
                var point = [];
                point.push(bottomLeftVertex[0] + (topLeftVertex[0] - bottomLeftVertex[0]) * 0.25 * l);
                point.push(bottomLeftVertex[1] + (topLeftVertex[1] - bottomLeftVertex[1]) * 0.25 * l);
                coordinates2.push(point);
                point = [];
                point.push(bottomRightVertex[0] + (topRightVertex[0] - bottomRightVertex[0]) * 0.25 * l);
                point.push(bottomRightVertex[1] + (topRightVertex[1] - bottomRightVertex[1]) * 0.25 * l);
                coordinates2.push(point);
                features2.push(feature2);
            }
        });
        linesOnMap = L.geoJson(jsonLines, {
            style: {
                color: "white", //border color
                opacity: "none", 
                weight: "1px" //Border thickness
            }
        }).addTo(geoMap).bringToBack();
        if (temporalActive) {
            linesMinMaxOnMap =  L.geoJson(jsonMinMaxLines, {
                style: {
                    color: "black", //border color
                    opacity: "none", 
                    weight: "2px" //Border thickness
                }
            }).addTo(geoMap).bringToFront();
        }
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
    if (roomBackgroundLayer != null)
        roomBackgroundLayer.bringToBack();
}

function getRoomsAndDrawRoomsWithRoomOverlays() {
    function onSuccess(response) {
        colletionOfRoomsOnMap = JSON.parse(response);
        drawRoomsForeground(colletionOfRoomsOnMap);
        splitRoomsIntoBarchart(colletionOfRoomsOnMap);
    }
    if (!temporalActive) {
        PageMethods.DrawFloor(currentFloorLevel, onSuccess);
    } else {
        TemporalUpdater();
    }

    getRoomsAndDrawBackground();
}

function drawMinMaxObservedLines(featuresLines, columnNumber, roomObservedMin, roomObservedMax, roomMin, roomMax, bottomRightVertex, bottomLeftVertex, topRightVertex, topLeftVertex) {
    //calc the hight for the min line
    var roomHeightMin = (1-(roomObservedMin - roomMin) / (roomMax - roomMin));
    if (roomHeightMin < 0) {
        roomHeightMin = 0;
    }
    else if (roomHeightMin > 1) {
        roomHeightMin = 1;
    }

    //calc the hight for the min line
    var roomHeightMax = (1-(roomObservedMax - roomMin) / (roomMax - roomMin));

    if (roomHeightMax < 0) {
        roomHeightMax = 0;
    }
    else if (roomHeightMax > 1) {
        roomHeightMax = 1;
    }

    drawlines = function (value, columnNumber, bottomLeftVertex, bottomRightVertex, topLeftVertex, topRightVertex) {
        var coordinates = new Array();

        var geometry =
            {
                type: "LineString",
                coordinates: coordinates
            };
        var feature = {
            type: "Feature",
            geometry: geometry
        }

        var point = [];
        point.push(topLeftVertex[0] + ((topRightVertex[0] - topLeftVertex[0]) / ActiveViews.length) * (columnNumber) - ((topLeftVertex[0] - bottomLeftVertex[0]) * value));
        point.push(topLeftVertex[1] + ((topRightVertex[1] - topLeftVertex[1]) / ActiveViews.length) * (columnNumber) - ((topLeftVertex[1] - bottomLeftVertex[1]) * value));
        coordinates.push(point);

        point = [];
        point.push(topLeftVertex[0] + ((topRightVertex[0] - topLeftVertex[0]) / ActiveViews.length) * (columnNumber + 1) - ((topLeftVertex[0] - bottomLeftVertex[0]) * value));
        point.push(topLeftVertex[1] + ((topRightVertex[1] - topLeftVertex[1]) / ActiveViews.length) * (columnNumber + 1) - ((topLeftVertex[1] - bottomLeftVertex[1]) * value));
        coordinates.push(point);

        featuresLines.push(feature);
    }
    drawlines(roomHeightMin, columnNumber, bottomLeftVertex, bottomRightVertex, topLeftVertex, topRightVertex);
    drawlines(roomHeightMax, columnNumber, bottomLeftVertex, bottomRightVertex, topLeftVertex, topRightVertex);
}

function getRoomsAndDrawRooms() {
    function onSuccess(response) {
        colletionOfRoomsOnMap = JSON.parse(response);
        splitRoomsIntoBarchart(colletionOfRoomsOnMap);
    }
    PageMethods.DrawFloor(currentFloorLevel, onSuccess);
}

function getRoomsAndDrawBackground() {
    function onSuccess(response) {
        var roomsBackground = JSON.parse(response);
        drawRoomsBackground(roomsBackground);
    }
    PageMethods.DrawRoomsBackground(currentFloorLevel, onSuccess);
}

function drawRoomsBackground(json) {
    if (roomBackgroundLayer != null) {
        geoMap.removeLayer(roomBackgroundLayer);
    }
    roomBackgroundLayer = L.geoJson(json, {
        style: backgroundStyle
    });
    var backLayer = 0;
    roomBackgroundLayer.setZIndex(backLayer).addTo(geoMap);
    roomBackgroundLayer.bringToBack();
}

function backgroundStyle(feature) {
    return {
        //Background color
        fillColor: getRoomBackgroundColor(feature.properties.RoomType),
        //border color
        color: getRoomBorderColor(feature.properties.RoomType),
        //Border thickness
        fillOpacity: 1.0
    };
}

function getRoomBackgroundColor(RoomType) {
    return RoomType === "Classroom" ? '#D0D6DC' :
           RoomType === "Studyzone" ? '#D0D6DC' :
           RoomType === "Office" ? '#C2B49D' :
           RoomType === "Hallway" ? '#C2B49D' :
           RoomType === "Stairs" ? '#C2B49D' :
           RoomType === "Elevator" ? '#C2B49D' :
           RoomType === "Toilet" ? '#C2B49D' :
           RoomType === "Utility" ? '#C2B49D' :
           '#FFFFFF';
}

function getRoomBorderColor(RoomType) {
    return RoomType === "Classroom" ? '#FFFFFF' :
           RoomType === "Studyzone" ? '#FFFFFF' :
           RoomType === "Office" ? '#C2B49D' :
           RoomType === "Hallway" ? '#C2B49D' :
           RoomType === "Stairs" ? '#C2B49D' :
           RoomType === "Elevator" ? '#C2B49D' :
           RoomType === "Toilet" ? '#C2B49D' :
           RoomType === "Utility" ? '#C2B49D' :
           '#FFFFFF';
}

function drawRoomsForeground(json) {

    if (roomForegroundLayer != null) {
        geoMap.removeLayer(roomForegroundLayer);
    }

    var roomOnClickEventHandler = function (feature, layer) {
        layer.on({
            click: onRoomClicked
        });
    };

    roomForegroundLayer = L.geoJson(json, {
        style: {
            //Background color
            fillColor: "#FFFFFF",
            //border color
            color: "#FFFFFF",
            //Border thickness
            weight: 3,
            opacity: 10,
            fillOpacity: 0.0
        },
        onEachFeature: roomOnClickEventHandler
    });
    var frontLayer = 1;
    roomForegroundLayer.setZIndex(frontLayer).addTo(geoMap);
}

function changeFloor() {
    roomArray = [];
    getRoomsAndDrawRoomsWithRoomOverlays();
}