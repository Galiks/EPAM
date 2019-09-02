function moveToPages() {
    let href;
    try {
      href = document.getElementById("nextPage").href;
      console.log(href);
      document.location.href = href;
    } catch {
      alert("ERROR! " + href);
    }
  }