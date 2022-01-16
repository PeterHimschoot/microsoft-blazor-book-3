let showOrUpdate = (elementId, zoom, markers) => {
  let elem = document.getElementById(elementId);
  if (!elem) {
    throw new Error('No element with ID ' + elementId);
  }

  // Initialize map if needed
  if (!elem.map) {
    elem.map = L.map(elementId).setView([50.88022, 4.29660], zoom);
    elem.map.addedMarkers = [];

    L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=***ACCESSTOKEN***', {
      attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
      maxZoom: 18,
      id: 'mapbox/streets-v11',
      tileSize: 512,
      zoomOffset: -1,
      accessToken: '***ACCESSTOKEN***'
    }).addTo(elem.map);
  }

  // Add markers 
  let map = elem.map;
  if (map.addedMarkers.length !== markers.length) {
    // Markers have changed, so reset
    map.addedMarkers.forEach(marker => marker.removeFrom(map));
    map.addedMarkers = markers.map(m => {
      return L.marker([m.y, m.x]).bindPopup(m.description).addTo(map);
    });

    // Auto-fit the view
    var markersGroup = new L.featureGroup(map.addedMarkers);
    map.fitBounds(markersGroup.getBounds().pad(0.3));

    // Show applicable popups. Can't do this until after the view was auto-fitted.
    markers.forEach((marker, index) => {
      if (marker.showPopup) {
        map.addedMarkers[index].openPopup();
      }
    });
  } else {
    // Same number of markers, so update positions/text without changing view bounds
    markers.forEach((marker, index) => {
      animateMarkerMove(
        map.addedMarkers[index].setPopupContent(marker.description),
        marker,
        4000);
    });
  }
};

let animateMarkerMove = (marker, coords, durationMs) => {
  if (marker.existingAnimation) {
    cancelAnimationFrame(marker.existingAnimation.callbackHandle);
  }

  marker.existingAnimation = {
    startTime: new Date(),
    durationMs: durationMs,
    startCoords: { x: marker.getLatLng().lng, y: marker.getLatLng().lat },
    endCoords: coords,
    callbackHandle: window.requestAnimationFrame(() => animateMarkerMoveFrame(marker))
  };
}

let animateMarkerMoveFrame = (marker) => {
  var anim = marker.existingAnimation;
  var proportionCompleted = (new Date().valueOf() - anim.startTime.valueOf()) / anim.durationMs;
  var coordsNow = {
    x: anim.startCoords.x + (anim.endCoords.x - anim.startCoords.x) * proportionCompleted,
    y: anim.startCoords.y + (anim.endCoords.y - anim.startCoords.y) * proportionCompleted
  };

  marker.setLatLng([coordsNow.y, coordsNow.x]);

  if (proportionCompleted < 1) {
    marker.existingAnimation.callbackHandle = window.requestAnimationFrame(
      () => animateMarkerMoveFrame(marker));
  }
}

export { showOrUpdate };