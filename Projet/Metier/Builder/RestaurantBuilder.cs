﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;
using Metier.Salle;
using Metier.Cuisine;


namespace Metier.Builder
{
    public class RestaurantBuilder : GeneralRestaurantBuilder
    {

        private Restaurant restaurant;

        public RestaurantBuilder()
        {
            this.restaurant = new Restaurant();
        }

        public void buildCarres(int nbCarre, int nbRangsParCarre, List<string> chefs, List<string> serveurs)
        {
            List<int> list = new List<int> { 2, 4, 6, 8, 10 };

            Random rnd = new Random();
            int compteur = 0;
            int compteurNumeroTable = 0;
            for (int i = 0; i < nbCarre; i++)
            {
                var carre = new Carre();
                carre.resto = restaurant;
                restaurant.carres.Add(carre);
                restaurant.carres[i].chefDeRang = new ChefDeRang(this.restaurant,restaurant.carres[i], chefs[i]);
                restaurant.carres[i].serveurs.Add(new Serveur(restaurant.carres[i], this.restaurant, serveurs[compteur]));
                compteur += 1;
                restaurant.carres[i].serveurs.Add(new Serveur(restaurant.carres[i], this.restaurant, serveurs[compteur]));
                compteur += 1;
                for (int j = 0; j < nbRangsParCarre; j++)
                {

                    var r = new Rang();
                    int compteurTailleTable = 0;
                    r.Carre = restaurant.carres[i];
                    restaurant.carres[i].rangs.Add(r);
                    
                    for (int k = 0; k < 5; k++)
                    {
                        compteurNumeroTable += 1;
                        var table = new Table(list[compteurTailleTable], compteurNumeroTable);
                        table.rang = r;
                        restaurant.carres[i].rangs[j].tables.Add(table);
                        compteurTailleTable += 1;
                    }
                    compteurTailleTable = 0;
                }
            }
        }

        public void buildMaitreHotel(string nomMaitreHotel)
        {
            restaurant.addMaitreHotel(new MaitreHotel(restaurant,nomMaitreHotel));
        }

        public void buildChefDeCuisine(string nomChefDeCuisine)
        {
            ChefDeCuisine chefDeCuisine = new ChefDeCuisine(restaurant, nomChefDeCuisine);
            chefDeCuisine.chefParties = new List<ChefDePartie>();
            chefDeCuisine.chefParties.Add(new ChefDePartie("Chef de partie 1", restaurant, new List<string>() {"Entrées", "Plat","Desserts"}));
            chefDeCuisine.chefParties.Add(new ChefDePartie("Chef de partie 2", restaurant, new List<string>() { "Entrées", "Plat","Desserts" }));
            restaurant.addChefDeCuisine(chefDeCuisine);
        }

        public void buildComptoir()
        {
            restaurant.comptoir = new Comptoir();
        }

        public Restaurant getRestaurant()
        {
            return this.restaurant;
        }
    }
}
