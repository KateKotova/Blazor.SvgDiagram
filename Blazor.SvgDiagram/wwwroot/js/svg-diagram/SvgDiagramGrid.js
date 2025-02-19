class SvgDiagramGrid {

    static className = "grid";

    _svg;
    _gridGroup;

    constructor(svg) {
        this._svg = svg;
    }

    _draw() {
        this._gridGroup?.rect(200, 200).fill('#00FF00AA');
    }

    _create() {
        this._gridGroup = this._svg.group().addClass(SvgDiagramGrid.className).back();
        this._draw();
    }

    _remove() {
        this._gridGroup.remove();
    }

    get isShown() {
        return !!this._svg.find(`.${SvgDiagramGrid.className}`).length;
    }

    show(shouldShow) {
        let isShown = this.isShown;

        if (shouldShow) {
            if (!isShown) {
                this._create();
            }
        } else {
            if (isShown) {
                this._remove();
            }
        }
    }
}