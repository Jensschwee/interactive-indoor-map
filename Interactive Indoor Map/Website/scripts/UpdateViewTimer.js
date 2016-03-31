setInterval(function () {
    function onSuccess(response) {
        colletionOfRoomsOnMap = JSON.parse(response);
        drawRooms();
        infoboxUpdate();
    }
    PageMethods.DrawFloor(currentFloorLevel, onSuccess);
}, 3000);