﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Metier.Cuisine;

namespace Metier.Salle
{
    public class Client : Personnel
    {
        public GroupeClient groupeClient;
        public Recette entree;
        public Recette plat;
        public Recette dessert;
        public int compteur = 0;

        public Client(GroupeClient groupeClient, string nom) : base(nom)
        {
            this.groupeClient = groupeClient;
        }

        public override void log(string log)
        {
            Console.WriteLine(log);
        }

        public override void tick()
        {
            compteur += 1;
            if (groupeClient.table.enumEtatTable == EnumEtatTable.ONT_CARTE && compteur == 5)
                 {  
                    
                    
                     groupeClient.table.enumEtatTable = EnumEtatTable.PRET_A_COMMANDE;
                     log("Table pret à commander, " + compteur );
                 }
        }
    }
}
