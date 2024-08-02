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

            // Représentation en chaîne de caractères de la note et affichage de l'etudiant
            public override string ToString()
            {
                return $"Étudiant: {NumeroEtudiant}, Cours: {NumeroCours}, Note: {Note}";
            }
        }

        private static void AjouterEtudiant(){
            // Affiche un en-tête pour la section d'ajout d'un étudiant
            Console.WriteLine("\n--- Ajouter un Étudiant ---");
            // Demande le numéro de l'étudiant et le lit depuis la console
            Console.Write("Numéro d'Étudiant : ");
            int numeroEtudiant = int.Parse(Console.ReadLine());
            // Demande le nom de l'étudiant et le lit depuis la console
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            // Demande le prénom de l'étudiant et le lit depuis la console
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();
            // Ajoute un nouvel objet Etudiant à la liste des étudiants
            etudiants.Add(new Etudiant(numeroEtudiant, nom, prenom));
            // Affiche un message de confirmation (commenté pour l'instant)
            Console.WriteLine(); // "Étudiant ajouté avec succès !");
        }

        private static void AjouterNote(){
            // Affiche un en-tête pour la section d'ajout d'une note
            Console.WriteLine("\n--- Ajouter une Note ---");
    
            // Demande le numéro de l'étudiant et le lit depuis la console
            Console.Write("Numéro d'Étudiant : ");
            int numeroEtudiant = int.Parse(Console.ReadLine());
    
            // Demande le numéro du cours et le lit depuis la console
            Console.Write("Numéro du Cours : ");
            int numeroCours = int.Parse(Console.ReadLine());
    
            // Demande la note et la lit depuis la console
            Console.Write("Note : ");
            double note = double.Parse(Console.ReadLine());
    
            // Ajoute un nouvel objet Notes à la liste des notes
            notes.Add(new Notes(numeroEtudiant, numeroCours, note));
    
            // Affiche un message de confirmation (commenté pour l'instant)
            Console.WriteLine(); // "Note ajoutée avec succès !");
    }

        private static void AjouterCours(){
        // Affiche un en-tête pour la section d'ajout d'un cours
        Console.WriteLine("\n--- Ajouter un Cours ---");
    
        // Demande le numéro du cours et le lit depuis la console
         Console.Write("Numéro du Cours : ");
         int numeroCours = int.Parse(Console.ReadLine());
    
        // Demande le code du cours et le lit depuis la console
        Console.Write("Code : ");
        string code = Console.ReadLine();
    
        // Demande le titre du cours et le lit depuis la console
        Console.Write("Titre : ");
        string titre = Console.ReadLine();
    
        // Ajoute un nouvel objet Cours à la liste des cours
        cours.Add(new Cours(numeroCours, code, titre));
    
        // Affiche un message de confirmation (commenté pour l'instant)
         Console.WriteLine(); // "Cours ajouté avec succès !");
        }

        private static void AfficherNotes()
        {
            // Affiche un en-tête pour la section d'affichage des notes d'un étudiant
            Console.WriteLine("\n--- Afficher les Notes d'un Étudiant ---");
            Console.Write("Numéro d'Étudiant à afficher : ");
            
                // Lit l'entrée utilisateur et la convertit en entier, représentant le numéro de l'étudiant
            int numeroEtudiant = int.Parse(Console.ReadLine());

                
                // Recherche dans la collection 'etudiants' l'étudiant avec le numéro d'étudiant donné
            var etudiant = etudiants.FirstOrDefault(e => e.NumeroEtudiant == numeroEtudiant);
            
                // Si l'étudiant n'est pas trouvé, affiche un message d'erreur et quitte la méthode
            if (etudiant == null)
            {
                Console.WriteLine("Étudiant introuvable.");
                return;
            }

                // Recherche toutes les notes de l'étudiant dans la collection 'notes'
            var etudiantNotes = notes.Where(n => n.NumeroEtudiant == numeroEtudiant).ToList();
            Console.WriteLine($"Relevé de notes pour l'Étudiant {etudiant.Nom} {etudiant.Prenom} ({numeroEtudiant}) :");

              // Parcourt toutes les notes de l'étudiant
            foreach (var note in etudiantNotes)
            {
                        // Recherche les informations du cours correspondant à la note
                var coursInfo = cours.FirstOrDefault(c => c.NumeroCours == note.NumeroCours);
                if (coursInfo != null)
                {
                    Console.WriteLine($"{coursInfo.Titre}: {note.Note}");
                }
                        // Si le cours n'est pas trouvé, affiche un message d'erreur pour ce numéro de cours
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
                // Affichage du menu de l'application
                Console.WriteLine("\n--- Gestion des Notes des Étudiants ---");
                Console.WriteLine("1. Ajouter un Étudiant");
                Console.WriteLine("2. Afficher les Notes d'un Étudiant");
                Console.WriteLine("3. Sauvegarder les Données");
                Console.Write("Choisissez une option : ");

                // Lecture du choix de l'utilisateur
                string choix = Console.ReadLine();

                // Exécution de l'option choisie
                switch (choix)
                { 
                    
                    // Si l'utilisateur choisit "1", appeler les méthodes pour ajouter un étudiant, un cours et une note
                    case "1":
                        AjouterEtudiant(); // Ajoute un étudiant
                        Console.WriteLine();
                        AjouterCours();// Ajoute un cours
                        Console.WriteLine();
                        AjouterNote();// Ajoute une note
                        Console.WriteLine("L'etudiant et ses informations ont ete enregistrer avec succes");
                        break;
                    
                    // Si l'utilisateur choisit "2", appeler la méthode pour afficher les notes d'un étudiant
                    case "2":
                        AfficherNotes();
                        break;
                    case "3":
                       SauvegarderDonnees();// Sauvegarde les données
                        break;
                                // Si l'utilisateur choisit une option invalide, afficher un message d'erreur
                    default:
                        Console.WriteLine("Option invalide. Veuillez réessayer.");
                        break;
                }
            }
        }
    }
}
