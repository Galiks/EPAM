const options = ["Option 1", "Option 2", "Option 3", "Option 4"];
let firstList = options;
let secondList = [];
const firstListElements = document.getElementById("first-list");
const secondListElements = document.getElementById("second-list");
let selectedOption = "";

const initFirstList = () => {
  firstList.forEach((option, index) => {
    const element = document.createElement("li");
    element.id = index + 1;
    element.innerText = option;
    element.style = element.id === selectedOption && "background:blue";
    element.onclick = onOptionClick;
    firstListElements.append(element);
  });
};

const initSecondList = () => {
  secondList.forEach((option, index) => {
    const element = document.createElement("li");
    element.id = index + 1;
    element.innerText = option;
    element.style = element.id === selectedOption && "background:blue";
    element.onclick = onOptionClick;
    secondListElements.append(element);
  });
};

const clearFirstList = () => {
  let child = firstListElements.lastElementChild;
  while (child) {
    firstListElements.removeChild(child);
    child = firstListElements.lastElementChild;
  }
};

const clearSecondList = () => {
  let child = secondListElements.lastElementChild;
  while (child) {
    secondListElements.removeChild(child);
    child = secondListElements.lastElementChild;
  }
};

const refreshLists = () => {
  if (firstList.length <= 0) {
    clearFirstList();
  } else {
    clearFirstList();
    initFirstList();
  }

  if (secondList.length <= 0) {
    clearSecondList();
  } else {
    clearSecondList();
    initSecondList();
  }
};

const moveAllOptionsRight = () => {
  if (firstList.length && !secondList.length) {
    secondList = firstList;
    firstList = [];
    refreshLists();
  } else if (firstList.length && secondList.length) {
    secondList.push(...firstList);
    firstList = [];
    refreshLists();
  }
};

const moveAllOptionsLeft = () => {
  if (secondList.length && !firstList.length) {
    firstList = secondList;
    secondList = [];
    refreshLists();
  } else if (secondList.length && firstList.length) {
    firstList.push(...secondList);
    secondList = [];
    refreshLists();
  }
};

const moveOneOptionRight = () => {
  if (selectedOption === "") {
    alert("Nothing is selected");
  } else {
    const foundElement = document.getElementById(selectedOption);
    const foundOption = `Option ${selectedOption.match(/\d+/)[0]}`;
    firstList = firstList.filter(option => option !== foundOption);
    secondList.push(foundOption);
    firstListElements.removeChild(foundElement);
    secondListElements.appendChild(foundElement);
  }
};

const moveOneOptionLeft = () => {
  if (selectedOption === "") {
    alert("Nothing is selected");
  } else {
    const foundElement = document.getElementById(selectedOption);
    const foundOption = `Option ${selectedOption.match(/\d+/)[0]}`;
    secondList = secondList.filter(option => option !== foundOption);
    firstList.push(foundOption);
    firstListElements.appendChild(foundElement);
    secondListElements.removeChild(foundElement);
  }
};

const onOptionClick = e => {
  if (selectedOption !== "") {
    document.getElementById(selectedOption).style = "background: none";
  }
  selectedOption = e.target.id;
  e.target.style = "background:blue";
};

document.getElementById("all-right").onclick = moveAllOptionsRight;
document.getElementById("all-left").onclick = moveAllOptionsLeft;
document.getElementById("one-right").onclick = moveOneOptionRight;
document.getElementById("one-left").onclick = moveOneOptionLeft;

initFirstList();
initSecondList();
