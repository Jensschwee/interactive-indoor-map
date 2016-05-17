setInterval(function () {
    if (!temporalActive) {
        getRoomsAndDrawRooms();
        infoboxDataUpdate();
    }
}, 2500);