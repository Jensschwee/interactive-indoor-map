function onRoomClicked(e) {
    var layer = e.target;

    if ($.inArray(layer.feature.properties.Name, roomArray) === -1) {
        //Select room
        layer.setStyle({
            //border color
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

        //Deselect room
        roomForegroundLayer.resetStyle(e.target);
        infoBox.update();
    }

    if (buildingButton.state('detoggled'))
        buildingButton.button.click();

    drawRoomInfo();
    infoboxUpdate = function () { drawSelectedRoomInfoBox(); };
    infoboxUpdate();
}