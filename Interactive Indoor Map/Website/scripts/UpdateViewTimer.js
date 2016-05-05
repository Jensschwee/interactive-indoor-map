setInterval(function () {
    if (!temporalActive) {
        getRoomsAndDrawRooms();
        infoboxUpdate();
    }
}, 3000);