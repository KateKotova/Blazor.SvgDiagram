let svgDiagram;

export function createSvgDiagram(svgId, width, height, shouldShowGrid) {
    svgDiagram = new SvgDiagram(svgId);
    svgDiagram.setParameters(width, height, shouldShowGrid);
}

export function updateSvgDiagramParameters(width, height, shouldShowGrid) {
    svgDiagram.setParameters(width, height, shouldShowGrid);
}