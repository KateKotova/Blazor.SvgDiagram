class SvgDiagramGrid {

    static className = "grid";
    static gridLineClassName = "svg-diagram-grid-line";

    _svg;
    _gridGroup;
    _step;
    _shouldShow = false;

    constructor(svg, step = 10) {
        this._svg = svg;
        this._step = step;
    }

    get isShown() {
        return !!this._svg.find(`.${SvgDiagramGrid.className}`).length;
    }

    get shouldShow() {
        return this._shouldShow;
    }

    set shouldShow(value) {
        this._shouldShow = value;

        let isShown = this.isShown;

        if (this._shouldShow) {
            if (!isShown) {
                this._create();
            }
        } else {
            if (isShown) {
                this._remove();
            }
        }
    }

    get step() {
        return this._step;
    }

    set step(value) {
        this._step = value;
        this._recreate();
    }

    _recreate() {
        if (this.isShown) {
            this._remove();
        }

        if (this._shouldShow) {
            this._create();
        }
    }

    _create() {
        this._gridGroup = this._svg.group().addClass(SvgDiagramGrid.className).back();
        this._draw();
    }

    _remove() {
        this._gridGroup.remove();
    }

    _draw() {
        if (!this._gridGroup) {
            return;
        }

        let width = this._svg.width();
        let height = this._svg.height();

        for (let verticalLineX = 0; verticalLineX < width; verticalLineX += this._step) {
            this._gridGroup.line(verticalLineX, 0, verticalLineX, height)
                .addClass(SvgDiagramGrid.gridLineClassName);
        }

        for (let horizontalLineY = 0; horizontalLineY < height; horizontalLineY += this._step) {
            this._gridGroup.line(0, horizontalLineY, width, horizontalLineY)
                .addClass(SvgDiagramGrid.gridLineClassName);
        }
    }
}