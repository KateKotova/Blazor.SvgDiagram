class SvgDiagramMovingControls {
    static mouseMoveEventName = "mousemove";
    static mouseDownEventName = "mousedown";
    static mouseUpEventName = "mouseup";
    static mouseOutEventName = "mouseout";

    selectionControls;

    mouseX;
    mouseY;

    constructor(selectionControls) {
        this.selectionControls = selectionControls;

        let controls = this;

        this.selectionControls.svgNode.addEventListener(
            SvgDiagramSelectionControls.selectedElementsWillBeChangedEventName,
            (event) => SvgDiagramMovingControls.onSelectedElementsWillBeChanged(event, controls,
                event.detail.selectedElements));

        this.selectionControls.svgNode.addEventListener(
            SvgDiagramSelectionControls.selectedElementsChangedEventName,
            (event) => SvgDiagramMovingControls.onSelectedElementsChanged(event, controls,
                event.detail.selectedElements));
    }

    static onSelectedElementsWillBeChanged(event, controls, selectedElements) {
        if (!selectedElements.length) {
            return;
        }

        for (let elementIndex = 0; elementIndex < selectedElements.length; elementIndex++) {
            let selectedElement = selectedElements[elementIndex];

            selectedElement.off(SvgDiagramMovingControls.mouseMoveEventName,
                (event) => SvgDiagramMovingControls.onSelectedElementPointerMove
                    (event, controls, selectedElement));

            selectedElement.off(SvgDiagramMovingControls.mouseDownEventName,
                (event) => SvgDiagramMovingControls.onSelectedElementPointerDown
                    (event, controls, selectedElement));

            selectedElement.off(SvgDiagramMovingControls.mouseUpEventName,
                (event) => SvgDiagramMovingControls.onSelectedElementPointerUp
                    (event, controls, selectedElement));
        }
    }

    static onSelectedElementsChanged(event, controls, selectedElements) {
        if (!selectedElements.length) {
            return;
        }

        for (let elementIndex = 0; elementIndex < selectedElements.length; elementIndex++) {
            let selectedElement = selectedElements[elementIndex];

            selectedElement.on(SvgDiagramMovingControls.mouseMoveEventName,
                (event) => SvgDiagramMovingControls.onSelectedElementPointerMove
                    (event, controls, selectedElement));

            selectedElement.on(SvgDiagramMovingControls.mouseDownEventName,
                (event) => SvgDiagramMovingControls.onSelectedElementPointerDown
                    (event, controls, selectedElement));

            selectedElement.on(SvgDiagramMovingControls.mouseUpEventName,
                (event) => SvgDiagramMovingControls.onSelectedElementPointerUp
                    (event, controls, selectedElement));
        }
    }

    static onSelectedElementPointerDown(event, controls, selectedElement) {
        controls.mouseX = event.clientX;
        controls.mouseY = event.clientY;
    }

    static onSelectedElementPointerUp(event, controls, selectedElement) {
        controls.mouseX = null;
        controls.mouseY = null;
    }

    static onSelectedElementPointerMove(event, controls, selectedElement) {
        if (controls.mouseX == null && controls.mouseY == null) {
            return;
        }

        let xOffset = event.clientX - controls.mouseX;
        let yOffset = event.clientY - controls.mouseY;

        controls.mouseX = event.clientX;
        controls.mouseY = event.clientY;

        controls.selectionControls.moveSelectedElements(xOffset, yOffset);
    }
}