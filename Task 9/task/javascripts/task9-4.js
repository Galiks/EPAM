function moveToPages() {
    let href;
    try {
      href = document.getElementById("next").href;
      console.log(href);
      document.location.href = href;
    } catch {
      alert("ERROR! " + href);
    }
  }
  
  moveToPages();