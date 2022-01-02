function calculator() {
    let object = {}
    return {
        init: (selector1, selector2, resultSelector) => {
            object.selectorOne = document.querySelector(selector1)
            object.selectorTwo = document.querySelector(selector2)
            object.selectorResult = document.querySelector(resultSelector)
        },
        add: () => {
            object.selectorResult.value = Number(object.selectorOne.value) + Number(object.selectorTwo.value);
        },
        subtract: () => {
            object.selectorResult.value = Number(object.selectorOne.value) - Number(object.selectorTwo.value);
        },
    }
}