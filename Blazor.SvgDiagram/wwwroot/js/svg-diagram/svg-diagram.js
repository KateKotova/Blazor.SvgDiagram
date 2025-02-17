export function createDiagram(diagramId) {
    var diagram = SVG(`#${diagramId}`).size(300, 300);
    diagram.rect(100, 100).move(100, 50).fill('#f06');
}