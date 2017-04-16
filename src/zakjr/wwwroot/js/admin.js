// Column dragging
let dragSrc = null;
let target = false;

function swapContentListData(a, b) {
    //const aTextArea = a.querySelector('textarea'), bTextArea = b.querySelector('textarea');
    //const aID = aTextArea.id, aName = aTextArea.name;
    //aTextArea.id = bTextArea.id;
    //aTextArea.name = bTextArea.name;
    //bTextArea.id = aID;
    //bTextArea.name = aName;
}

function setSequenceField() {
    let index = 0;
    document.querySelectorAll('.dragger-row').forEach(function (col) {
        col.querySelector(".input--sequence").value = index;
        index++;
    });
}

function onDragMouseDown(e) {
    target = e.target;
}

function onDragStart(e) {
    if (this.querySelector('.dragger-handle').contains(target)) {
        this.classList.add('dragger-state--dragging');

        dragSrc = this;

        e.dataTransfer.effectAllowed = 'move';
        e.dataTransfer.setData('text/html', this.innerHTML);
    }
}

function onDragOver(e) {
    if (e.preventDefault) e.preventDefault();
    e.dataTransfer.dropEffect = 'move';
    return false;
}

function onDragEnter(e) {
    this.classList.add('dragger-state--over');
}

function onDragLeave(e) {
    this.classList.remove('dragger-state--over');
}

function onDragDrop(e) {
    if (e.stopPropagation) e.stopPropagation();

    if (dragSrc !== this) {
        dragSrc.innerHTML = this.innerHTML;
        this.innerHTML = e.dataTransfer.getData('text/html');
        swapContentListData(this, dragSrc);
        setSequenceField();
    }

    return false;
}

function onDragEnd(e) {
    [].forEach.call(cols, function (col) {
        col.classList.remove('dragger-state--over');
        col.classList.remove('dragger-state--dragging');
    });
}

var cols = document.querySelectorAll(".dragger-row");
[].forEach.call(cols, function (col) {
    col.addEventListener('dragstart', onDragStart, false);
    col.addEventListener('dragover', onDragOver, false);
    col.addEventListener('dragenter', onDragEnter, false);
    col.addEventListener('dragleave', onDragLeave, false);
    col.addEventListener('drop', onDragDrop, false);
    col.addEventListener('dragend', onDragEnd, false);
    col.addEventListener('mousedown', onDragMouseDown, false);
});
