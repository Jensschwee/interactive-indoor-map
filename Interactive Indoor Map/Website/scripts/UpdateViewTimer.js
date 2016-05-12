setInterval(function () {
    if (!temporalActive) {
        getRoomsAndDrawRooms();
        infoboxUpdate();
    }
}, 2500);