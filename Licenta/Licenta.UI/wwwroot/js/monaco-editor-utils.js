const initialize = (eltId, initialCode, programmingLanguage) => {
	require.config({ paths: { vs: 'monaco-editor/dev/vs' } });

	require(['vs/editor/editor.main'], function () {
		var editor = monaco.editor.create(document.getElementById(eltId), {
			value: initialCode,
			language: programmingLanguage
		});
	});
}


var MonacoEditorUtils = {
	initialize: initialize,
}