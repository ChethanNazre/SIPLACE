using SiplaceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SiplaceApp.Services
{
    public class XMLParser
    {
        public Recipe ParseRecipe(string filePath)
        {
            try
            {
                XDocument doc = XDocument.Load(filePath);
                XElement root = doc.Root;

                var recipe = new Recipe
                {
                    RecipeName = root.Attribute("Name")?.Value ?? "Unknown",
                    ImportedDate = DateTime.Now,
                    SetupDetails = new List<SetupDetail>()
                };

                var lineElement = root.Descendants("Line").FirstOrDefault();
                if (lineElement != null)
                {
                    recipe.LineName = lineElement.Attribute("Name")?.Value ?? "Unknown";
                }

                var board = root.Descendants("Board").FirstOrDefault();
                if (board != null)
                {
                    recipe.ModelName = board.Attribute("Name")?.Value ?? "";
                }
                recipe.BoardSide = "Right";

                ParseSetupDetails(root, recipe);
                return recipe;
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing XML file.", ex);
            }
        }

        private void ParseSetupDetails(XElement root, Recipe recipe)
        {
            var positions = root.Descendants("Position").ToList();
            var pickups = root.Descendants("Pickup").ToList();

            for (int i = 0; i < positions.Count && i < pickups.Count; i++)
            {
                var posElement = positions[i];
                var pickupElement = pickups[i];

                var detail = new SetupDetail
                {
                    Recipe = recipe,
                    PartNumber = posElement.Attribute("Component")?.Value ?? "",
                    ReferenceDesignators = posElement.Attribute("ReferenceDesignator")?.Value ?? "",
                    Table = pickupElement.Attribute("Table")?.Value ?? "",
                    Track = pickupElement.Attribute("Track")?.Value ?? "",
                    FeederType = pickupElement.Attribute("FeederType")?.Value ?? "",
                    Quantity = 1
                };
                var station = posElement.Ancestors("Station").FirstOrDefault();
                if (station != null)
                {
                    detail.MachineName = station.Attribute("Name")?.Value ?? "";
                }
                recipe.SetupDetails.Add(detail);
            }
        }
    }
}