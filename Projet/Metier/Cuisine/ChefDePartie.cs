﻿using Metier.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Cuisine
{
    public class ChefDePartie : Personnel
    {
        public List<Recette> recettes;
        public List<string> roles;
        public Restaurant restaurant;
        public int compteurPrepa = 0;
        public int compteurRecette = 0;
        public int statChefDePartie = 0;
        
        public ChefDePartie(string nom, Restaurant r, List<string> roles) : base(nom)
        {
            this.recettes = new List<Recette>();
            this.restaurant = r;
            this.roles = roles;
        }

        public override Restaurant getRestaurant()
        {
            return restaurant;
        }


        public void PreparerRecette()
        {
            foreach (Recette r in recettes)
            {
                //Attendre tps preparation + cuisson + repos
                //this.restaurant.comptoir.recettesAServir.Enqueue(r);
;            }
        }

        public override void tick()
        {
            if(recettes.Count != 0)
            {
                compteurPrepa += 1;
                if (compteurPrepa == 20)
                {

                    statChefDePartie += compteurPrepa;
                    compteurPrepa = 0;
                    recettes.First().etat = true;
                    if (recettes.First().categorie.Equals("Entrées"))
                    {
                        restaurant.comptoir.entreesAServir.Enqueue(recettes.First());
                        log("Entrée préparé : " + recettes.First().titre);
                    }

                    if (recettes.First().categorie.Equals("Plat"))
                    {
                        restaurant.comptoir.platsAServir.Enqueue(recettes.First());
                        log("Plat préparé : " + recettes.First().titre);
                    }

                    if (recettes.First().categorie.Equals("Desserts"))
                    {
                        restaurant.comptoir.dessertsAServir.Enqueue(recettes.First());

                        log("Dessert préparé : " + recettes.First().titre);
                    }
                    recettes.Remove(recettes.First());
                }
            }
            
        }
    }

}
