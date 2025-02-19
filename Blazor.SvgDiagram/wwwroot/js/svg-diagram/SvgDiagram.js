class SvgDiagram {
    #svgId;
    #grid;

    #selectionControls;
    #movingControls;

    svg;

    constructor(svgId, gridStep) {
        this.#svgId = svgId;
        this.svg = SVG(`#${this.#svgId}`);
        if (!this.#svgId) {
            return;
        }

        this.#grid = new SvgDiagramGrid(this.svg, gridStep);

        this.#selectionControls = new SvgDiagramSelectionControls(this.svg);
        this.#movingControls = new SvgDiagramMovingControls(this.#selectionControls);

        var rect1 = this.svg.rect(100, 100).move(100, 50).fill('#f06');
        var rect2 = this.svg.rect(200, 200).move(300, 100).fill('#00f');

        this.#selectionControls.addSelectableElement(rect1);
        this.#selectionControls.addSelectableElement(rect2);
    }

    setParameters(width, height, shouldShowGrid, gridSetp) {
        if (!this.#svgId) {
            return;
        }

        this.svg.size(width, height);
        this.#grid.step = gridSetp;
        this.#grid.shouldShow = shouldShowGrid;
    }
}