// Import Blockly core.
import * as Blockly from 'blockly/core.js';
// Import the default blocks.
import * as libraryBlocks from 'blockly/blocks.js';
// Import a generator.
import { javascriptGenerator } from 'blockly/javascript.js';
// Import a message file.
import * as Ru from 'blockly/msg/ru.js';

Blockly.setLocale(Ru);

export const init = (toolbox) => {
    let workspace = Blockly.inject("blocklyDiv", {
        toolbox: toolbox
    })

    var originalFuntion = javascriptGenerator.forBlock['math_number'];

    javascriptGenerator.forBlock['math_number'] = function (block, generator) {
        var [value, order] = originalFuntion(block, generator)
        return [value + 'n', order];
    }

    return workspace;
};

export const generate = (workspace) => {
    return javascriptGenerator.workspaceToCode(workspace)
};

export const save = (workspace) => {
    return JSON.stringify(Blockly.serialization.workspaces.save(workspace))
};