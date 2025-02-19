let svgDiagram;
const svgDiagramGridStep = 20;

export function createSvgDiagram(svgId, width, height, shouldShowGrid, gridStep) {
    svgDiagram = new SvgDiagram(svgId, svgDiagramGridStep);
    svgDiagram.setParameters(width, height, shouldShowGrid, gridStep);
}

export function updateSvgDiagramParameters(width, height, shouldShowGrid, gridStep) {
    svgDiagram.setParameters(width, height, shouldShowGrid, gridStep);
}