class SvgDiagram {

    _svgId;
    _svg;
    _grid;

    constructor(svgId) {
        this._svgId = svgId;
        this._svg = SVG(`#${this._svgId}`);
        if (!this._svgId) {
            return;
        }

        this._grid = new SvgDiagramGrid(this._svg);
        this._draw();
    }

    _draw() {
        this._svg.rect(100, 100).move(100, 50).fill('#f06');
    }

    setParameters(width, height, shouldShowGrid) {
        if (!this._svgId) {
            return;
        }

        this._svg.size(width, height);
        this._grid.show(shouldShowGrid);
    }
}