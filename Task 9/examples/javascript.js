var item = document.getElementById("output");
try{
	item.value = "Test!!!!!!";
}
catch {
	alert(`${item} is null`)
}