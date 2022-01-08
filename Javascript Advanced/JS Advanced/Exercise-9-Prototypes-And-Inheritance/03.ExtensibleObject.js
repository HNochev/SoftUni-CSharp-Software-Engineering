function extensibleObject() {
    // create prototype object
    let proto = {};
    // create extensibleObject with prototype proto
    let extObj = Object.create(proto);

    //add extend function to extensibleObject
    extObj.extend = function (template) {
        //iterate keys of template obj
        for (const key in template) {

            //if template obj property is function => add to prototype
            if (typeof template[key] === 'function') {
                let proto = Object.getPrototypeOf(this);
                proto[key] = template[key];
            }
            //if template obj property is not function -> add to extensible object
            else {
                this[key] = template[key];
            }

        }
    }

    return extObj;
}

let a = extensibleObject();