(function() {
  let getElement = new Promise((resolve, reject) => {
    var div = document.getElementById("pop-up");
    resolve(div);
  });

  function displayElement(element) {
    element.style.display = "flex";
  }

  function wait() {
    return new Promise((resolve, reject) => {
      setTimeout(resolve, 2000);
    });
  }

  function redirect() {
    let path = "https://www.youtube.com/watch?v=-jkMnq2Hfzo";
    window.location = path;
  }

  wait()
    .then(() => {
      getElement.then(element => displayElement(element));
      return wait();
    })
    .then(() => {
      redirect();
    });
})();
