   M S B A M L   `   `   `  ����P  LZarządzanieBudżetem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:ZarządzanieBudżetem.ImportExel ZarządzanieBudżetem.ImportExel  5      Q-clr-namespace:ZarządzanieBudżetem.View.UserZarządzanieBudżetem.View.User  5      .    (ZarządzanieBudżetem.View.User.TaskPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      E
importExel.clr-namespace:ZarządzanieBudżetem.ImportExel     5      BuserView-clr-namespace:ZarządzanieBudżetem.View.User     5        N� Title$  TaskPage��5
      .��5      � 
�������.+�5   
   �� $��1q�6   
���   �$��100,10,44,159q�69   ._�5      �� $
��Auto=�6   $��
0,0,-84,20q�6>   .��5      &   System.Windows.Controls.DataGrid  -   5        $��TaskListView��5         AutoGenerateColumns .  $��10,27,100,50q�6i   ��.  $	��600��6�   ��6K   �� *Tasks+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 L.p.��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Lp+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Nazwa Kosztu��61   $	 300 6G      CellTemplate 5      �� 5   "   .R�5   &   ��  �� TextWrapping$
 Wrap=�6q   ��6.   �� *Nazwa_Kosztu+ �� UpdateSourceTrigger$ PropertyChanged=�6q   5   #   5        5      $ Wartość Ogółem��6-   $
 Auto 6h    6E   �� *Wartość_Ogółem+6h     5      $ Wydatki Kwalifikowane��6-   $
 Auto 6v    6L   �� *Wydatki_Kwalifikowane+6v     5      $ Dofinansowanie��6-   $
 Auto 6h    6E   �� *Dofinansowanie+6h     5      $ Kategoria Kosztów��6-   $
 Auto 6n    6H   �� *Kategoria_Kosztów+6n     5       $ Pozostałe Środki��6-   $
 Auto 6l   	   
IsReadOnly	 .  6G   �� *Pozostałe_Środki+6y     5!      $ Wydane��6-   $
 Auto 6_   	 .  6=   �� *Suma_Wydatków+6l     5"      $ Ilość Personelu��6-   $
 Auto 6j    6F   �� *Ilość_Personelu+6j   4  .System.Windows.Controls.DataGridCheckBoxColumn  5#      $ Zakończone��61   $
 Auto 6q    6E   �� *Zakończone+
 �� Mode$
 TwoWay=�6q   5*      5+      5,      �� 5-   
   -   5        $��Załaduj z Excela��5-      $
��Left=�6G   $	��Top=�6b   $��	0,490,0,0q�6z   $��49��6�   $��95��6�   �� 5.   
   -   5        $��Details��5.      $��Szczegóły��6    $
��Left=�64   $��39��6O   $��
10,117,0,0q�6[   $	��Top=�6o   $��85��6�   6�   �� 5/   
   -   5        $
��Save��5/      $��Zapisz��6   $
��Left=�6.   $��37��6I   $��
10,188,0,0q�6U   $	��Top=�6i   $��85��6�   6�   �� 50   
   -   5        $
��Back��50   "   $��Powrót��6   $
��Left=�6.   $��37��6I   $��	10,30,0,0q�6U   $	��Top=�6h   $��85��6�   6�   �� 51   
   -   5        $��Delete��51       $��Usuń��6   $
��Left=�6.   $��36��6I   $��
10,252,0,0q�6U   $	��Top=�6i   $��85��6�   6�   52      53      