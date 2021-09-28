/*
 * Created by SharpDevelop.
 * User: Kyle Hendrickson
 * Date: 04/01/2021
 * Time: 13:55
 * 
 */
using System;
using System.Windows;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace StringViewer
{
	public partial class Window1 : Window
	{	
		// Set up values for consonants.
		long consonantsNumber;
		String consonantsString;
		Double consonantsPercent = new Double();
		Point consonantsPoint0;
		Point consonantsPoint1;
		Point consonantsPoint2;
		Point consonantsPoint3;
		Point consonantsPoint4;
		
		// Set up values for vowels.
		long vowelsNumber;
		String vowelsString;
		Double vowelsPercent = new Double();
		Point vowelsPoint0;
		Point vowelsPoint1;
		Point vowelsPoint2;
		Point vowelsPoint3;
		Point vowelsPoint4;
		
		// Set up values for spaces.
		long spacesNumber;
		String spacesString;
		Double spacesPercent = new Double();
		Point spacesPoint0;
		Point spacesPoint1;
		Point spacesPoint2;
		Point spacesPoint3;
		Point spacesPoint4;
		
		// Set up values for letters.
		long lettersNumber;
		String lettersString;
		Double lettersPercent = new Double();
		Point lettersPoint0;
		Point lettersPoint1;
		Point lettersPoint2;
		Point lettersPoint3;
		Point lettersPoint4;
		
		// Set up values for numbers.
		long numbersNumber;
		String numbersString;
		Double numbersPercent = new Double();
		Point numbersPoint0;
		Point numbersPoint1;
		Point numbersPoint2;
		Point numbersPoint3;
		Point numbersPoint4;
		
		// Set up values for symbols.
		long symbolsNumber;
		Double symbolsPercent = new Double();
		Point symbolsPoint0;
		Point symbolsPoint1;
		Point symbolsPoint2;
		Point symbolsPoint3;
		Point symbolsPoint4;
		
		// Set up values for the total character string.
		long totalCharsString;
		
		// Set up values for textbox manipulation.
		String stringInfo;
		String stringInfoUpper;
		
		// Constructor that creates the window object.
		public Window1()
		{
			// Call the method that creates the window component.
			InitializeComponent();
		}
		
		// Method that updates all the gui elements when the contents of the textbox change.
		public void mainTextChanged(object sender, EventArgs args)
		{
			
			// Set the string in the main text box.
			stringInfo = mainText.Text;
			totalCharsString = stringInfo.Length;
			stringInfoUpper = stringInfo.ToUpper();
			
			// Reset the points of this polygon to prevent stale data.
			consonantsPoint0 = new Point(93.2,88);
			consonantsPoint1 = new Point(98.4,84.92);
			consonantsPoint2 = new Point(100,83.4);
			consonantsPoint3 = new Point(101.5,84.9);
			consonantsPoint4 = new Point(106.8,87);
			
			// Reset the points of this polygon to prevent stale data.
			vowelsPoint0 = new Point(108.8,88);
			vowelsPoint1 = new Point(114.3,91.2);
			vowelsPoint2 = new Point(115.4,92.3);
			vowelsPoint3 = new Point(115.4,93.86);
			vowelsPoint4 = new Point(115.4,99);
			
			// Reset the points of this polygon to prevent stale data.
			spacesPoint0 = new Point(115.4,101);
			spacesPoint1 = new Point(115.4,106.1);
			spacesPoint2 = new Point(115.4,107.7);
			spacesPoint3 = new Point(114.3,108.8);
			spacesPoint4 = new Point(108.8,111.94);
			
			// Reset the points of this polygon to prevent stale data.
			symbolsPoint0 = new Point(106.8,111.94);
			symbolsPoint1 = new Point(101.5,115);
			symbolsPoint2 = new Point(100,116);
			symbolsPoint3 = new Point(98.44,115);
			symbolsPoint4 = new Point(93.2,111.94);
			
			// Reset the points of this polygon to prevent stale data.
			numbersPoint0 = new Point(91.2,111.94);
			numbersPoint1 = new Point(85.7,108.8);
			numbersPoint2 = new Point(84.6,107.7);
			numbersPoint3 = new Point(84.6,106.1);
			numbersPoint4 = new Point(84.6,101);
			
			// Reset the points of this polygon to prevent stale data.
			lettersPoint0 = new Point(84.6,99);
			lettersPoint1 = new Point(84.6,93.86);
			lettersPoint2 = new Point(84.6,92.3);
			lettersPoint3 = new Point(85.7,91.2);
			lettersPoint4 = new Point(91.2,88);
			
			// Set the text for the labels to the default.
			letterPercentLabel.Text = "0%";
			numberPercentLabel.Text = "0%";
			vowelsPercentLabel.Text = "0%";
			vowelsPercentLabelBlack.Text = "0%";
			consonantPercentLabel.Text = "0%";
			spacesPercentLabel.Text = "0%";
			symbolsPercentLabel.Text = "0%";
			symbolsPercentLabelBlack.Text = "0%";
			
			// This gets the total characters.
			totalCharsBox.Width = Math.Min(Math.Max(43 * (0.23 * (totalCharsString.ToString().Length)),16),43);
			totalCharsNumberLabel.Text = Math.Min(totalCharsString,99999).ToString();
			
			// Increase margin by 10 for each char that is present in totalcharsnumberlabel
			totalCharLabel.Margin = new Thickness(totalCharsNumberLabel.Text.Length * -5,-4,0,0);
			totalBox.Margin = new Thickness(6 * -totalCharsNumberLabel.Text.Length,-4,0,0);
			
			// This gets the number of non number chars in the string, and then subtracts it from the total to find out the number count.
			numbersString = String.Join("",stringInfo.Split('0','1','2','3','4','5','6','7','8','9'));
			numbersString = (numbersString.Length - totalCharsString).ToString();
			numbersNumber = Math.Abs(long.Parse(numbersString));
			
			// Set the max amount of countable numbers for the text label to 100K -1.
			numbersCharLabel.Text = Math.Min(numbersNumber,99999) + "";
			
			// Set the width of the border to a number that is wide enough to contain the number of digits.
			// Use math min and max to set a min and max width for the border.
			numbersBorder.Width = Math.Min(Math.Max(43 * (0.23 * (numbersNumber.ToString().Length)),16),43);
			
			// This removes all the letters from the string (upper or lower case), and then subtracts it from the 
			// total to figure out the letter count.
			lettersString = String.Join("",stringInfoUpper.Split('A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'));
			lettersString = (lettersString.Length - totalCharsString).ToString();
			lettersNumber = Math.Abs(long.Parse(lettersString));
			
			// Set the letters label for the radar graph, and make sure the border fits.
			lettersCharLabel.Text = Math.Min(lettersNumber,99999) + "";
			lettersBorder.Width = Math.Min(Math.Max(43 * (0.23 * (lettersNumber.ToString().Length)),16),43);
				
			// This removes the spaces from the text input and then subtracts it from the total.
			spacesString = String.Join("",stringInfo.Split(' ')); 
			spacesString = (spacesString.Length - totalCharsString).ToString();
			spacesNumber = Math.Abs(long.Parse(spacesString));
			
			// Set the spaces label for the radar graph, and make sure the border fits.
			spacesCharLabel.Text = Math.Min(spacesNumber,99999) + "";
			spacesBorder.Width = Math.Min(Math.Max(43 * (0.23 * (spacesNumber.ToString().Length)),16),43);
				
			// This gets the number of vowels.
			vowelsString = String.Join("",stringInfoUpper.Split('A','E','I','O','U','Y'));
			vowelsString = (vowelsString.Length - totalCharsString).ToString();
			vowelsNumber = Math.Abs(long.Parse(vowelsString));
			
			// Set the vowels label for the radar graph, and make sure the border fits.
			vowelsCharLabel.Text = Math.Min(vowelsNumber,99999) + "";
			vowelsBorder.Width = Math.Min(Math.Max(43 * (0.23 * (vowelsNumber.ToString().Length)),16),43);
				
			// This gets the number of consonants.
			consonantsString = String.Join("",stringInfoUpper.Split('B','C','D','F','G','H','J','K','L','M','N','P','Q','R','S','T','V','W','X','Z'));
			consonantsString = (consonantsString.Length - totalCharsString).ToString();
			consonantsNumber = Math.Abs(long.Parse(consonantsString));
			
			// Set the consonants label for the radar graph, and make sure the border fits.
			consonantsCharLabel.Text = Math.Min(consonantsNumber,99999) + "";
			consonantsBorder.Width = Math.Min(Math.Max(43 * (0.23 * (consonantsNumber.ToString().Length)),16),43);
			
			// This gets the number of symbols based on the other values.(if we count all data points there will be overlap).
			symbolsNumber = Math.Abs(lettersNumber + numbersNumber + spacesNumber - totalCharsString);
			symbolsCharLabel.Text = Math.Min(symbolsNumber,99999) + "";
			symbolsBorder.Width = Math.Min(Math.Max(43 * (0.23 * (symbolsNumber.ToString().Length)),16),43);
			
			// Divide the total number of charaters by the percent number and convert each to a double to save the decimals.
			consonantsPercent = Convert.ToDouble(consonantsNumber) / Convert.ToDouble(totalCharsString);
			vowelsPercent = Convert.ToDouble(vowelsNumber) / Convert.ToDouble(totalCharsString);
			spacesPercent = Convert.ToDouble(spacesNumber) / Convert.ToDouble(totalCharsString);
			symbolsPercent = Convert.ToDouble(symbolsNumber) / Convert.ToDouble(totalCharsString);
			numbersPercent = Convert.ToDouble(numbersNumber) / Convert.ToDouble(totalCharsString);
			lettersPercent = Convert.ToDouble(lettersNumber) / Convert.ToDouble(totalCharsString);
			
			// If any of the percentages are not a number.
			if(double.IsNaN(consonantsPercent) || double.IsNaN(vowelsPercent) || double.IsNaN(spacesPercent) || double.IsNaN(symbolsPercent) || double.IsNaN(numbersPercent) || double.IsNaN(lettersPercent))
			{
				// Assign the percentages to 0.
				consonantsPercent = 0;
				vowelsPercent = 0;
				spacesPercent = 0;
				symbolsPercent = 0;
				numbersPercent = 0;
				lettersPercent = 0;
			}
			
			// Set bar graphs to values.
			lettersBar.Width = lettersPercent * 120;
			numbersBar.Width = numbersPercent * 120;
			vowelsBar.Width = vowelsPercent * 120;
			vowelsPercentLabel.Margin = new Thickness(0,0,vowelsBar.Width,0);
			consonantsBar.Width = consonantsPercent * 120;
			spacesBar.Width = spacesPercent * 120;
			symbolsBar.Width = symbolsPercent * 120;
			symbolsPercentLabel.Margin = new Thickness(symbolsBar.Width,0,0,0);
			
			// If the user inputted text box has no text.
			if(stringInfo.Length == 0)
			{
				// Set the bar graphs to the minimum value.
				lettersBar.Width = 5;
				numbersBar.Width = 5;
				vowelsBar.Width = 5;
				consonantsBar.Width = 5;
				spacesBar.Width = 5;
				symbolsBar.Width = 5;
			}
			
			// If letters percent is less than half a percent.
			if(lettersPercent < 0.5)
			{
				// Set the width of the bar to the default.
				lettersBar.Width = 5 + lettersPercent * 120;
			}
			// If numbers percent is less than half a percent.
			if(numbersPercent < 0.5)
			{
				// Set the width of the bar to the default.
				numbersBar.Width = 5 + numbersPercent * 120;
			}
			// If the vowels percent is less than half a percent.
			if(vowelsPercent < 0.5)
			{
				// Set the width of the bar to the default.
				vowelsBar.Width = 5 + vowelsPercent * 120;
				vowelsPercentLabel.Margin = new Thickness(0,0,vowelsBar.Width,0);
			}
			// If the consonants percent is less than half a percent.
			if(consonantsPercent < 0.5)
			{
				// Set the width of the bar to the default.
				consonantsBar.Width = 5 + consonantsPercent * 120;
			}
			// If the spaces percent is less than half a percent.
			if(spacesPercent < 0.5)
			{
				// Set the width of the bar to the default.
				spacesBar.Width = 5 + spacesPercent * 120;
			}
			// If the spaces percent is less than half a percent.
			if(symbolsPercent < 0.5)
			{
				// Set the width of the bar to the default.
				symbolsBar.Width = 5 + symbolsPercent * 120;
				symbolsPercentLabel.Margin = new Thickness(symbolsBar.Width,0,0,0);
			}
			
			// If the number of letters is more than 0.
			if(lettersNumber > 0)
			{
				// Set the letters label to the percentage for letters.
				letterPercentLabel.Text = string.Format("{0:0.#}",lettersPercent * 100) + "%";
			}
			// If the number of numbers is more than 0.
			if(numbersNumber > 0)
			{
				// Set the numbers label to the percentage for numbers.
				numberPercentLabel.Text = string.Format("{0:0.#}",numbersPercent * 100) + "%";
			}
			// If the number of vowels is more than 0.
			if(vowelsNumber > 0)
			{
				// Set the vowels label to the percentage for vowels.
				vowelsPercentLabel.Text = string.Format("{0:0.#}",vowelsPercent * 100) + "%";
				vowelsPercentLabelBlack.Text = string.Format("{0:0.#}",vowelsPercent * 100) + "%";
			}
			// If the number of consonants is more than 0.
			if(consonantsNumber > 0)
			{
				// Set the consonants label to the percentage for consonants.
				consonantPercentLabel.Text = string.Format("{0:0.#}",consonantsPercent * 100) + "%";
			}
			// If the number of spaces is more than 0.
			if(spacesNumber > 0)
			{
				// Set the spaces label to the percentage for spaces.
				spacesPercentLabel.Text = string.Format("{0:0.#}", spacesPercent * 100) + "%";
			}
			// If the number of symbols is more than 0.
			if(symbolsNumber > 0)
			{
				// Set the symbols label to the percentage for symbols.
				symbolsPercentLabel.Text = string.Format("{0:0.#}", symbolsPercent * 100) + "%";
				symbolsPercentLabelBlack.Text = string.Format("{0:0.#}", symbolsPercent * 100) + "%";
			}			
			
			// If the consonants percentage is between 0.2 and 1.
			if(consonantsPercent <= 1 && consonantsPercent > 0.2)
			{
				// Set the point values for the polygon on the radar graph.
				consonantsPoint1 = new Point((-10.92 * consonantsPercent) + 100,((89.1 * consonantsPercent) - 100) * -1);
				consonantsPoint2 = new Point(0 + 100,((93.8 * consonantsPercent) - 100) * -1);
				consonantsPoint3 = new Point((10.92 * consonantsPercent) + 100,((89.1 * consonantsPercent) - 100) * -1);
			}
			// If the vowels percent is between 0.2 and 1.
			if(vowelsPercent <= 1 && vowelsPercent > 0.2)
			{	
				// Set the point values for the polygon on the radar graph.
				vowelsPoint1 = new Point((86.1 * vowelsPercent) + 100,((54.6 * vowelsPercent) - 100) * -1);
				vowelsPoint2 = new Point((93.8 * vowelsPercent) + 100,((46.9 * vowelsPercent) - 100) * -1);
				vowelsPoint3 = new Point((93.8 * vowelsPercent) + 100,((35.98 * vowelsPercent) - 100) * -1);
			}
			// If the spaces percentage is between 0.2 and 1.
			if(spacesPercent <= 1 && spacesPercent > 0.2)
			{
				// Set the point values for the polygon on the radar graph.
				spacesPoint1 = new Point((93.8 * spacesPercent) + 100,((-35.98 * spacesPercent) - 100) * -1);
				spacesPoint2 = new Point((93.8 * spacesPercent) + 100,((-46.9 * spacesPercent) - 100) * -1);
				spacesPoint3 = new Point((86.1 * spacesPercent) + 100,((-54.6 * spacesPercent) - 100) * -1);

			}
			// If the symbols percentage is between 0.2 and 1.
			if(symbolsPercent <= 1 && symbolsPercent > 0.2)
			{
				// Set the point values for the polygon on the radar graph.
				symbolsPoint1 = new Point((10.92 * symbolsPercent) + 100,((-89.1 * symbolsPercent) - 100) * -1);
				symbolsPoint2 = new Point(0 + 100,((-93.8 * symbolsPercent) - 100) * -1);
				symbolsPoint3 = new Point((-10.92 * symbolsPercent) + 100,((-89.1 * symbolsPercent) - 100) * -1);
			}
			// If the numbers percentage is between 0.2 and 1.
			if(numbersPercent <= 1 && numbersPercent > 0.2)
			{	
				// Set the point values for the polygon on the radar graph.
				numbersPoint1 = new Point((-86.1 * numbersPercent) + 100,((-54.6 * numbersPercent) - 100) * -1);
				numbersPoint2 = new Point((-93.8 * numbersPercent) + 100,((-46.9 * numbersPercent) - 100) * -1);
				numbersPoint3 = new Point((-93.8 * numbersPercent) + 100,((-35.98 * numbersPercent) - 100) * -1);
			}
			// If the letters percentage is between 0.2 and 1.
			if(lettersPercent <= 1 && lettersPercent > 0.2)
			{
				// Set the point values for the polygon on the radar graph.
				lettersPoint1 = new Point((-93.8 * lettersPercent) + 100,((35.98 * lettersPercent) - 100) * -1);
				lettersPoint2 = new Point((-93.8 * lettersPercent) + 100,((46.9 * lettersPercent) - 100) * -1);
				lettersPoint3 = new Point((-86.1 * lettersPercent) + 100,((54.6 * lettersPercent) - 100) * -1);
			}
			
			// Side Points are set to the nearest low value point for their neighbour, so that the shapes are always together.
			// Set the points that connect all the polygons together on the radar graph, based on the other points that were just set.
			// Each connection uses 2 points.
			
			// Set connection points for the consonants polygon.
			consonantsPoint4.X = 46.9 * Math.Max(Math.Min(consonantsPercent,vowelsPercent),0.2) + 98;
			consonantsPoint4.Y = (70.35 * Math.Max(Math.Min(consonantsPercent,vowelsPercent),0.2) - 102) * -1;
			consonantsPoint0.X = -46.9 * Math.Max(Math.Min(lettersPercent,consonantsPercent),0.2) + 102;
			consonantsPoint0.Y = (70.35 * Math.Max(Math.Min(lettersPercent,consonantsPercent),0.2) - 102) * -1;
			
			// Set connection points for the vowels polygon.
			vowelsPoint0.X = 46.9 * Math.Max(Math.Min(consonantsPercent,vowelsPercent),0.2) + 100;
			vowelsPoint0.Y = (70.35 * Math.Max(Math.Min(consonantsPercent,vowelsPercent),0.2) - 103) * -1;
			vowelsPoint4.X = 100 * Math.Max(Math.Min(spacesPercent,vowelsPercent),0.2) + 96;
			vowelsPoint4.Y = (1 - 100) * -1;
	
			// Set connection points for the spaces polygon.
			spacesPoint0.X = 100 * Math.Max(Math.Min(spacesPercent,vowelsPercent),0.2) + 96;
			spacesPoint0.Y = (-1 - 100) * -1;
			spacesPoint4.X = 46.9 * Math.Max(Math.Min(spacesPercent,symbolsPercent),0.2) + 100;
			spacesPoint4.Y = (-70.35 * Math.Max(Math.Min(spacesPercent,symbolsPercent),0.2) - 97.5) * -1;
			
			// Set connection points for the symbols polygon.
			symbolsPoint0.X = 46.9 * Math.Max(Math.Min(spacesPercent,symbolsPercent),0.2) + 98;
			symbolsPoint0.Y = (-70.35 * Math.Max(Math.Min(spacesPercent,symbolsPercent),0.2) - 98) * -1; 
			symbolsPoint4.X = -46.9 * Math.Max(Math.Min(numbersPercent,symbolsPercent),0.2) + 102;
			symbolsPoint4.Y = (-70.35 * Math.Max(Math.Min(numbersPercent,symbolsPercent),0.2) - 98) * -1;
			
			// Set connection points for the numbers polygon.
			numbersPoint0.X = -46.9 * Math.Max(Math.Min(numbersPercent,symbolsPercent),0.2) + 100;
			numbersPoint0.Y = (-70.35 * Math.Max(Math.Min(numbersPercent,symbolsPercent),0.2) - 97.5) * -1;
			numbersPoint4.X = -100 * Math.Max(Math.Min(numbersPercent,lettersPercent),0.2) + 104;
			numbersPoint4.Y = (-1 - 100) * -1;
	
			// Set connection points for the letters polygon.
			lettersPoint0.X = -100 * Math.Max(Math.Min(numbersPercent,lettersPercent),0.2) + 105;
			lettersPoint0.Y = (1 - 100) * -1;
			lettersPoint4.X = -46.9 * Math.Max(Math.Min(lettersPercent,consonantsPercent),0.2) + 100;
			lettersPoint4.Y = (70.35 * Math.Max(Math.Min(lettersPercent,consonantsPercent),0.2) - 103) * -1;
			
			// If consonant percent and letters percent are both 1.
			if(consonantsPercent.Equals(1) && lettersPercent.Equals(1))
			{
				// Set the point values to compliment eachother.
				lettersPoint4.X = (lettersPoint3.X + consonantsPoint1.X) /2 -1;
				lettersPoint4.Y = (lettersPoint3.Y + consonantsPoint1.Y) /2 +1;
				consonantsPoint0.X = (lettersPoint3.X + consonantsPoint1.X) /2 +1;
				consonantsPoint0.Y = (lettersPoint3.Y + consonantsPoint1.Y) /2;
			}
			
			// Create and draw the path for the consonants polygon.
			PathFigureCollectionConverter pfcc = new PathFigureCollectionConverter();
			PathGeometry consonantsGeometry = new PathGeometry();
			consonantsGeometry.Figures = (PathFigureCollection)pfcc.ConvertFrom(
			"M100,99 " +
			"L" + consonantsPoint0.X + "," + consonantsPoint0.Y + " " +
			"L" + consonantsPoint1.X + "," + consonantsPoint1.Y + " " +
			"Q" + consonantsPoint2.X + "," + consonantsPoint2.Y + " " +
			consonantsPoint3.X +"," + consonantsPoint3.Y + " " +
			"L" +  consonantsPoint4.X + "," + consonantsPoint4.Y + " " +
			"L100,99");
			
			// Create and draw the path for the vowels polygon.
			PathGeometry vowelsGeometry = new PathGeometry();
			vowelsGeometry.Figures = (PathFigureCollection)pfcc.ConvertFrom(
			"M102,99 " +
			"L" + vowelsPoint0.X + "," + vowelsPoint0.Y + " " +
			"L" + vowelsPoint1.X + "," + vowelsPoint1.Y + " " +
			"Q" + vowelsPoint2.X + "," + vowelsPoint2.Y + " " +
			vowelsPoint3.X + "," + vowelsPoint3.Y + " " +
			"L" + vowelsPoint4.X + "," + vowelsPoint4.Y + " " +
			"L102,99");
			
			// Create and draw the path for the spaces polygon.
			PathGeometry spacesGeometry = new PathGeometry();
			spacesGeometry.Figures = (PathFigureCollection)pfcc.ConvertFrom(
			"M102,101 " +
			"L" + spacesPoint0.X + "," + spacesPoint0.Y +
			"L" + spacesPoint1.X + "," + spacesPoint1.Y + " " +
			"Q" + spacesPoint2.X + "," + spacesPoint2.Y + " " +
			spacesPoint3.X +"," + spacesPoint3.Y + " " +
			"L" + spacesPoint4.X + "," + spacesPoint4.Y + " " +
			"L102,101");
			
			// Create and draw the path for the symbols polygon.
			PathGeometry symbolsGeometry = new PathGeometry();
			symbolsGeometry.Figures = (PathFigureCollection)pfcc.ConvertFrom(
			"M100,101 " + 
			"L" + symbolsPoint0.X + "," + symbolsPoint0.Y + " " +
			"L" + symbolsPoint1.X +  "," + symbolsPoint1.Y + " " +
			"Q" + symbolsPoint2.X + "," + symbolsPoint2.Y + " " +
			symbolsPoint3.X +"," + symbolsPoint3.Y + " " +
			"L" + symbolsPoint4.X + "," + symbolsPoint4.Y + " " +
			"L100,101");
			
			// Create and draw the path for the numbers polygon.
			PathGeometry numbersGeometry = new PathGeometry();
			numbersGeometry.Figures = (PathFigureCollection)pfcc.ConvertFrom(
			"M98,101 " + 
			"L" + numbersPoint0.X + "," + numbersPoint0.Y + " " +
			"L" + numbersPoint1.X +  "," + numbersPoint1.Y + " " +
			"Q" + numbersPoint2.X + "," + numbersPoint2.Y + " " +
			numbersPoint3.X +"," + numbersPoint3.Y + " " +
			"L" + numbersPoint4.X + "," + numbersPoint4.Y + " " +
			"L98,101");
			
			// Create and draw the path for the letters polygon.
			PathGeometry lettersGeometry = new PathGeometry();
			lettersGeometry.Figures = (PathFigureCollection)pfcc.ConvertFrom(
			"M98,99 " + 
			"L" + lettersPoint0.X + "," + lettersPoint0.Y + " " +
			"L" + lettersPoint1.X +  "," + lettersPoint1.Y + " " +
			"Q" + lettersPoint2.X + "," + lettersPoint2.Y + " " +
			lettersPoint3.X +"," + lettersPoint3.Y + " " +
			"L" + lettersPoint4.X + "," + lettersPoint4.Y + " " +
			"L98,99");
			
			// Create the geometry for displaying the polygons to the gui.
			consonantsRadar.Data = consonantsGeometry;
			vowelsRadar.Data = vowelsGeometry;
			spacesRadar.Data = spacesGeometry;
			symbolsRadar.Data = symbolsGeometry;
			numbersRadar.Data = numbersGeometry;
			lettersRadar.Data = lettersGeometry;
			
		}
		
		// Method for catching user input in the text box.
		public void mainTextClicked(object sender, EventArgs args)
		{
			// If the default text is in the box when the user clicks.
			if(mainText.Text.Equals("Type or Paste Here to Begin!"))
			{
				// Delete the text so the user can add their own.
				mainText.Text = "";
			}
		}
		
		// Method for catching if the user clicks exit.
		public void exitClicked(object sender, EventArgs args)
		{
			// Shut down application.
			Application.Current.Shutdown();
		}
		
		// Method for catching if the user clicks minimize.
		public void minimizeWindow(object sender, EventArgs args)
		{
			// Set the window state to minimized.
			WindowState = WindowState.Minimized;
		}
		
		// Method for catching if the user is trying to drag the window.
		public void dragWindow(object sender, EventArgs args)
		{
			//Allow the user to drag the window.
			DragMove();
		}
		
		// Method for catching if the user clicks the Flip button.
		public void flipText(object sender, EventArgs args)
		{
			// Reverse the order of the letters in the text box, then set the textbox's text to the new string.
			char[] mainTextArray = mainText.Text.ToCharArray();
			Array.Reverse(mainTextArray);
			mainText.Text = new string(mainTextArray);
		}
		
		// Method for catching if the user clicks the Uppercase button.
		public void upperCaseText(object sender, EventArgs args)
		{
			// Set all the text in the text box to uppercase.
			mainText.Text = mainText.Text.ToUpper();
		}
		
		// Method for catching if the user clicks the Lowercase.
		public void lowerCaseText(object sender, EventArgs args)
		{
			// Set all the text in the text box to lowercase.
			mainText.Text = mainText.Text.ToLower();
		}
		
		// Method for catching if the user clicks the Drop Symbols button.
		public void removeSymbolsText(object sender, EventArgs args)
		{
			// Replace all non alphanumberic characters in the text box with no character.
			mainText.Text = Regex.Replace(mainText.Text, @"[^0-9a-zA-Z ]+", "");
		}
		
	}
}