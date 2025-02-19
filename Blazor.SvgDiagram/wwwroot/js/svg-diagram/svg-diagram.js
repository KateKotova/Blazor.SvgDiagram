const gridClassName = "grid";
let svg;
let gridGroup;

export function createSvgDiagram(diagramId, width, height, shouldShowGrid) {
    svg = SVG(`#${diagramId}`);
    if (!svg) {
        return;
    }

    svg.size(width, height);
    showGrid(shouldShowGrid);

    svg.rect(100, 100).move(100, 50).fill('#f06');
}

export function updateSvgDiagramParameters(width, height, shouldShowGrid) {
    if (!svg) {
        return;
    }

    svg.size(width, height);
    showGrid(shouldShowGrid);
}

function createGrid() {
    gridGroup = svg.group().addClass(gridClassName).back();
    gridGroup.rect(200, 200).fill('#00FF00AA');
}

function gridExists() {
    return !!svg.find(`.${gridClassName}`).length;
}

function removeGrid() {
    gridGroup.remove();
}
function showGrid(shouldShowGrid) {
    let gridIsShown = gridExists();

    if (shouldShowGrid) {
        if (!gridIsShown) {
            createGrid();
        }
    } else {
        if (gridIsShown) {
            removeGrid();
        }
    }
}