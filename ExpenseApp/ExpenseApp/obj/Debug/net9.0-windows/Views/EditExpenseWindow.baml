   M S B A M L   `   `   `  ����E  AExpenseApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ExpenseApp.ViewsExpenseApp.Views  5   	   =#clr-namespace:ExpenseApp.ViewModelsExpenseApp.ViewModels  5   	   ;"clr-namespace:ExpenseApp.ConventerExpenseApp.Conventer  5   	   5clr-namespace:ExpenseApp.ModelsExpenseApp.Models  5	   	   (    "ExpenseApp.Views.EditExpenseWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ExpenseApp.Views     5   	   :
viewModels#clr-namespace:ExpenseApp.ViewModels     5   	   3conv"clr-namespace:ExpenseApp.Conventer     5   	   2modelsclr-namespace:ExpenseApp.Models     5	   	     � Title$)  #Редагувати витрату��5   	   $	��300��6$   $	��400��61    � WindowStartupLocation$ CenterOwner=�5   	    � 	Resources 5      ,   &ExpenseApp.Conventer.CategoryConventer   CategoryConventer��%   &	          5   
   6!   5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Категорія:��6   $��0��6&   $��0��63   $��	0,0,10,10q�6C   �� 5   
   $��0��6   $��1��6    $��0,0,0,10q�60   ��5       �� *AvailableCategories+ �� SelectedItem 5!      �� *EditingExpense.Category+ �� Mode$ TwoWay=���5"      �� 5#      .R�5$      �� ��6    ��  �� 	Converter# [  5%      5'      �� 5)   
   $��	Сума:��6   $��1��6!   $��0��6.   $��	0,0,10,10q�6>   �� 5*   
   $��1��6   $��1��6   $��0,0,0,10q�6/   ��5+      �� *EditingExpense.Amount+ �� UpdateSourceTrigger$ PropertyChanged=��� 5-   
   $��	Опис:��6   $��2��6!   $��0��6.   $��	0,0,10,10q�6>   �� 5.   
   $��2��6   $��1��6   $��0,0,0,10q�6/   ��5/      �� *EditingExpense.Description+$ PropertyChanged=��� 51   
   $��	Дата:��6   $��3��6!   $��0��6.   $��	0,0,10,10q�6>   (  "System.Windows.Controls.DatePicker  52   
   $��3��6   $��1��6"   $��0,0,0,10q�62   	   SelectedDate	 53      �� *EditingExpense.Date+�� 55   
   $��5��6   $��2��6"   
 �� Orientation$
 
Horizontal=�56      $��Right=�6.   .+�57      �� $��Зберегти��6   $��80��58      $��0,0,10,0q�6    ��57   (   �� *SaveCommand+58       �� 59      $��Закрити��6   $��80��5:      ��59   '   �� *CloseCommand+5:      5;      5<      5=      