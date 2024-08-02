using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AssuanceUA3.Program;

namespace AssuanceUA3
{
    internal class Program
    {
        private static List<Etudiant> etudiants = new List<Etudiant>();
        private static List<Cours> cours = new List<Cours>();
        private static List<Notes> notes = new List<Notes>();

        public class Etudiant
        {
            // Propriétés de l'étudiant
            public int NumeroEtudiant { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }

            // Constructeur pour initialiser un étudiant
            public Etudiant(int numeroEtudiant, string nom, string prenom)
            {
                NumeroEtudiant = numeroEtudiant;
                Nom = nom;
                Prenom = prenom;
            }

            // Représentation en chaîne de caractères de l'étudiant
            public override string ToString()
            {
                return $"Étudiant: {NumeroEtudiant}, Nom: {Nom}, Prénom: {Prenom}";
            }
        }

        public class Cours
        {
            // Propriétés du cours
            public int NumeroCours { get; set; }
            public string Code { get; set; }
            public string Titre { get; set; }

            // Constructeur pour initialiser un cours
            public Cours(int numeroCours, string code, string titre)
            {
                NumeroCours = numeroCours;
                Code = code;
                Titre = titre;
            }

            // Représentation en chaîne de caractères du cours
            public override string ToString()
            {
                return $"Cours: {NumeroCours}, Code: {Code}, Titre: {Titre}";
            }
        }

        // Classe pour représenter les notes d'un étudiant dans un cours
        public class Notes
        {
            // Propriétés des notes
            public int NumeroEtudiant { get; set; }
            public int NumeroCours { get; set; }
            public double Note { get; set; }

            // Constructeur pour initialiser une note
            public Notes(int numeroEtudiant, int numeroCours, double note)
            {
                NumeroEtudiant = numeroEtudiant;
                NumeroCours = numeroCours;
                Note = note;
            }

            // Représentation en chaîne de caractères de la note
            public override string ToString()
            {
                return $"Étudiant: {NumeroEtudiant}, Cours: {NumeroCours}, Note: {Note}";
            }
        }

        private static void AjouterEtudiant()
        {
            Console.WriteLine("\n--- Ajouter un Étudiant ---");
            Console.Write("Numéro d'Étudiant : ");
            int numeroEtudiant = int.Parse(Console.ReadLine());
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();
            etudiants.Add(new Etudiant(numeroEtudiant, nom, prenom));
            Console.WriteLine();//"Étudiant ajouté avec succès !");
        }

        private static void AjouterNote()
        {
            Console.WriteLine("\n--- Ajouter une Note ---");
            Console.Write("Numéro d'Étudiant : ");
            int numeroEtudiant = int.Parse(Console.ReadLine());
            Console.Write("Numéro du Cours : ");
            int numeroCours = int.Parse(Console.ReadLine());
            Console.Write("Note : ");
            double note = double.Parse(Console.ReadLine());
            notes.Add(new Notes(numeroEtudiant, numeroCours, note));
            Console.WriteLine();// "Note ajoutée avec succès !");
        }

        private static void AjouterCours()
        {
            Console.WriteLine("\n--- Ajouter un Cours ---");
            Console.Write("Numéro du Cours : ");
            int numeroCours = int.Parse(Console.ReadLine());
            Console.Write("Code : ");
            string code = Console.ReadLine();
            Console.Write("Titre : ");
            string titre = Console.ReadLine();
            cours.Add(new Cours(numeroCours, code, titre));
            Console.WriteLine();// "Cours ajouté avec succès !");
        }

        private static void AfficherNotes()
        {
            Console.WriteLine("\n--- Afficher les Notes d'un Étudiant ---");
            Console.Write("Numéro d'Étudiant à afficher : ");
            int numeroEtudiant = int.Parse(Console.ReadLine());

            var etudiant = etudiants.FirstOrDefault(e => e.NumeroEtudiant == numeroEtudiant);
            if (etudiant == null)
            {
                Console.WriteLine("Étudiant introuvable.");
                return;
            }

            var etudiantNotes = notes.Where(n => n.NumeroEtudiant == numeroEtudiant).ToList();
            Console.WriteLine($"Relevé de notes pour l'Étudiant {etudiant.Nom} {etudiant.Prenom} ({numeroEtudiant}) :");

            foreach (var note in etudiantNotes)
            {
                var coursInfo = cours.FirstOrDefault(c => c.NumeroCours == note.NumeroCours);
                if (coursInfo != null)
                {
                    Console.WriteLine($"{coursInfo.Titre}: {note.Note}");
                }
                else
                {
                    Console.WriteLine($"Cours introuvable pour le numéro de cours {note.NumeroCours}");
                }
            }
        }


        static void Main(string[] args)
        {

            // Boucle principale du menu
            while (true)
            {
                // Affichage du menu
                Console.WriteLine("\n--- Gestion des Notes des Étudiants ---");
                Console.WriteLine("1. Ajouter un Étudiant");
              //  Console.WriteLine("2. Ajouter un Cours");
              //  Console.WriteLine("3. Ajouter une Note");
              //  Console.WriteLine("4. Afficher les Notes d'un Étudiant");
                Console.WriteLine("5. Sauvegarder les Données");
                Console.Write("Choisissez une option : ");

                // Lecture du choix de l'utilisateur
                string choix = Console.ReadLine();

                // Exécution de l'option choisie
                switch (choix)
                {
                    case "1":
                        AjouterEtudiant();
                        Console.WriteLine();
                        AjouterCours();
                        Console.WriteLine();
                        AjouterNote();
                        Console.WriteLine("L'etudiant et ses informations ont ete enregistrer avec succes");
                        break;
                    case "2":
                        AfficherNotes();
                        break;
                    case "3":
                    //    SauvegarderDonnees();
                        break;
                    default:
                        Console.WriteLine("Option invalide. Veuillez réessayer.");
                        break;
                }
            }
        }
    }
}
