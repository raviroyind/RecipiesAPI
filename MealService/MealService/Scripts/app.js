var ViewModel = function () {

   
    var self = this;
    self.recipes = ko.observableArray();//for all recipies
    self.error = ko.observable();// errors
    self.detail = ko.observable();// recipie detail
    self.isLoading = ko.observable(false);
    var recipesUri = '/api/recipies/';

    

    function ajaxHelper(uri, method, data) {
        self.error(''); // clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    

    function getAllRecipes() {
        self.isLoading(true);
        ajaxHelper(recipesUri, 'GET').done(function (data) {
            self.recipes(data);
        });
        self.isLoading(false);
    }

    self.getRecipieDetail = function (item) {
        ajaxHelper(recipesUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

   


    self.chefs = ko.observableArray();//following used for adding new record.
    self.newRecipie = {
        Chef: ko.observable(),
        RecipieName: ko.observable(),
        Description: ko.observable(),
        PreparationTime: ko.observable(),
        Serves: ko.observable(),
        OriginCountry: ko.observable()
    }


    var chefsUri = '/api/chefs/';


    function getChefs() {
        ajaxHelper(chefsUri, 'GET').done(function (data) {
            self.chefs(data);
        });
    }

    self.addRecipie = function (formElement) {
        var recipie = {
            ChefId: self.newRecipie.Chef().Id,
            RecipieName: self.newRecipie.RecipieName(),
            Description: self.newRecipie.Description(),
            PreparationTime: self.newRecipie.PreparationTime(),
            Serves: self.newRecipie.Serves(),
            OriginCountry: self.newRecipie.OriginCountry()
        };

        ajaxHelper(recipesUri, 'POST', recipie).done(function (item) {
            self.recipes.push(item);
            self.newRecipie.RecipieName(null);
            self.newRecipie.Description(null);
            self.newRecipie.PreparationTime(null);
            self.newRecipie.Serves(null);
            self.newRecipie.OriginCountry(null);
        });
        
    }
    

    self.deleteRecipie = function (recipie) {

        if (confirm('Are you sure to Delete "' + recipie.RecipieName + '" Recipie??')) {
            var id = recipie.Id;

            ajaxHelper(recipesUri + id, 'DELETE', recipie).done(function (item) {
                self.recipes.remove(item);
                getAllRecipes();
            });
        }
    }
    // data fetch.
    getAllRecipes();
    getChefs();
};

ko.applyBindings(new ViewModel());

