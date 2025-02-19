let svgDiagram;
const svgDiagramGridStep = 20;

export function createSvgDiagram(svgId, width, height, shouldShowGrid, gridStep) {
    svgDiagram = new SvgDiagram(svgId, svgDiagramGridStep);
    svgDiagram.setParameters(width, height, shouldShowGrid, gridStep);

    svgDiagram.svg.node.addEventListener(
        SvgDiagramSelectionControls.selectedElementsInformationChangedEventName,
        (event) => onSelectedElementsInformationChanged(event, event.detail.informationLines));
}

export function updateSvgDiagramParameters(width, height, shouldShowGrid, gridStep) {
    svgDiagram.setParameters(width, height, shouldShowGrid, gridStep);
}

function onSelectedElementsInformationChanged(event, informationLines) {
    console.log('-------------');
    if (!informationLines.length) {
        return;
    }

    for (var lineIndex = 0; lineIndex < informationLines.length; lineIndex++) {
        console.log(informationLines[lineIndex]);
    }
}