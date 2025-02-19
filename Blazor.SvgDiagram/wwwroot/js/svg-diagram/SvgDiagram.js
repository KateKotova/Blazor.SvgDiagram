class SvgDiagram {

    _svgId;
    _svg;
    _grid;

    constructor(svgId, gridStep) {
        this._svgId = svgId;
        this._svg = SVG(`#${this._svgId}`);
        if (!this._svgId) {
            return;
        }

        this._grid = new SvgDiagramGrid(this._svg, gridStep);
        this._draw();
    }

    setParameters(width, height, shouldShowGrid, gridSetp) {
        if (!this._svgId) {
            return;
        }

        this._svg.size(width, height);
        this._grid.step = gridSetp;
        this._grid.shouldShow = shouldShowGrid;
    }

    _draw() {
        this._svg.rect(100, 100).move(100, 50).fill('#f06');
    }
}