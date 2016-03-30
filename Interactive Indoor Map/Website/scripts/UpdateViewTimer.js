setInterval(function () {
    function onSuccess(response) {
        colletionOfRoomsOnMap = JSON.parse(response);
        drawRooms();
    }
    //PageMethods.DrawFloor(currentFloorLevel, onSuccess);
}, 3000);