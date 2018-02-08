(function() {
  let getLocation = new Promise((resolve, reject) => {
    navigator.geolocation.getCurrentPosition(location =>
      resolve(location.coords)
    );
  });

  getLocation.then(coords => {
    let img = document.getElementById("map");

    let latitude = coords.latitude;
    let longitude = coords.longitude;

    let imgsrc = `http://maps.googleapis.com/maps/api/staticmap?center=${latitude},${longitude}&zoom=13&size=500x500&sensor=false`;

    img.setAttribute("src", imgsrc);
  });
})();
