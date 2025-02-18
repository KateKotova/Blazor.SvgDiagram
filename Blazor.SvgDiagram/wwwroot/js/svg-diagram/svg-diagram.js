export function createSvgDiagram(diagramId, width, height) {
    var diagram = SVG(`#${diagramId}`).size(width, height);
    diagram.rect(100, 100).move(100, 50).fill('#f06');
}

export function updateSvgDiagramParameters(diagramId, width, height) {
    SVG(`#${diagramId}`).size(width, height);
}