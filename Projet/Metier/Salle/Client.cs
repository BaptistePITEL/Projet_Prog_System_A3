﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Metier.Cuisine;
using Metier.Factory;

namespace Metier.Salle
{
    public class Client : Personnel
    {
        public GroupeClient groupeClient;
        public Recette entree;
        public Recette plat;
        public Recette dessert;


        public Recette platRecu;

        public int compteur = 0;
        public FabriqueRecette fR = new FabriqueRecette();

        public Client(GroupeClient groupeClient, string nom) : base(nom)
        {
            this.groupeClient = groupeClient;
        }

        public override Restaurant getRestaurant()
        {
            return groupeClient.table.rang.Carre.resto;
        }

        public override void tick()
        {
            compteur += 1;
            if (groupeClient.table.enumEtatTable == EnumEtatTable.ONT_CARTE && compteur == 5)
            {
                this.entree = fR.create(1, groupeClient.table);
                this.plat = fR.create(2, groupeClient.table);
                this.dessert = fR.create(3, groupeClient.table);



                groupeClient.checkToutLeMondePret();
                    //table.enumEtatTable = EnumEtatTable.PRET_A_COMMANDE;
                log(nom+" prêt a commander, " + compteur );
            }
            else  if (platRecu != null)
            {                
                if (groupeClient.table.enumEtatTable == EnumEtatTable.COMMANDE_EMISE)
                     groupeClient.checkToutLeMondeRecu();              

                
            }
        }
    }
}
