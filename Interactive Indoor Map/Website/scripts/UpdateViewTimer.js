setInterval(function () {
    if (!temporalActive) {
        getRoomsAndDrawRooms();
        infoboxDateUpdate();
    }
}, 3000);