define(["sitecore", "jquery"], function (Sitecore, $) {
    var AssetEditorPage = Sitecore.Definitions.App.extend({
        initialized: function () {

            var id = this.getID();

            if (id != null) {
                this.getProperty(id);
            }
        },

        getID: function () {
            return Sitecore.Helpers.url.getQueryParameters(window.location.href)['id'];
        },

        getProperty: function (id) {
            var app = this;

            jQuery.ajax({
                type: "GET",
                dataType: "json",
                url: "/api/sitecore/Property/GetProperty",
                data: { 'id': id, 'dbName': 'master' },
                cache: false,
                success: function (data) {
                    app.populateForm(data);
                },
                error: function () {

                }
            });
        },

        populateForm: function (data) {
            var app = this;
            console.dir(app);
            app.AssetField.set('text', data);
        },
    });

    return AssetEditorPage
});