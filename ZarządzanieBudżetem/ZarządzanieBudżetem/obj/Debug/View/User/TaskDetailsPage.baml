   M S B A M L   `   `   `  ����P  LZarządzanieBudżetem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ZarządzanieBudżetem.View.UserZarządzanieBudżetem.View.User  5      5    /ZarządzanieBudżetem.View.User.TaskDetailsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:ZarządzanieBudżetem.View.User     5        N� Title$  TaskDetailsPage��5	      .��5      � 
�������.+�5   
   �� $��1q�6   
���   �$	��800��69   $��78,19,122,457q�6E   ._�5      �� $
��Auto=�6   .��5      &   System.Windows.Controls.DataGrid  -   5        $��InvoiceListView��5         AutoGenerateColumns .  $��22,27,56,59q�6o   ��.  ��6N   �� *
Invoices+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Nr faktury��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *
Nr_faktury+6`     5      $ Kwota��6-   $
 Auto 6V    6<   �� *Kwota+6V     5      $
 Opis��6-   $	 350 6T    6;   �� *Opis+6T     5      $ Data Faktury��6-   $
 Auto 6�    6C   �� *Data_Faktury+ �� StringFormat$ {0:dd-MM-yyyy}��6�     5      $ 	Jednostka��6-   $
 Auto 6^    6@   �� *	Jednostka+6^     5      $ Budynek��6-   $
 Auto 6Z    6>   �� *	Budynek+6Z     5      $ Pokój��6-   $
 Auto 6V    6<   �� *Pokój+6V   5      5      5      �� 5   
   $��1q�6   
���   �$	��800��69   $��178,400,222,50q�6E   ._�5      �� $
��Auto=�6   .��5        -   5        $��WnioskiListView��5       .  $��22,27,56,59q�6o   ��.  ��6N   �� *
Requests+ 5        5       $ Nr Księgowy��6-   $
 Auto 6a    6B   �� *NrKsięgowy+6a     5!      $ Data Wniosku��6-   $
 Auto 6d    6C   �� *Data_Wniosku+6d     5"      $ Kwota Dofinansowania��6-   $
 Auto 6t    6K   �� *Kwota_Dofinansowania+6t   5&      5'      5(      �� 5)   
   -   5        $
��Save��5)      $��Zapisz��6   $��Center=�6.   $��44��6K   $��1041,299,0,0q�6W   $	��Top=�6m   $	��104��6�   6�   �� 5*   
   -   5        $��AddInv��5*      $��Dodaj fakture��6   $��Center=�67   $��1041,38,0,0q�6T   $	��Top=�6i   $��44��6�   $	��104��6�   6�   �� 5+   
   -   5        $
��Back��5+      $��Powrót��6   $
��Left=�6.   $��44��6I   $��	39,33,0,0q�6U   $	��Top=�6h   $	��111��6�   6�   �� 5,   
   -   5        $��AddReq��5,      $��Dodaj wniosek��6   $��Center=�67   $��1041,419,0,0q�6T   $	��Top=�6j   $��44��6�   $	��104��6�    J� RenderTransformOrigin$ 0.445,-1.125&�6�   �� 5-   
   -   5        $��	DeleteInv��5-      $��Usuń fakture��6"   $��Center=�69   $��1041,106,0,0q�6V   $	��Top=�6l   $��44��6�   $	��104��6�   6�   �� 5.   
   -   5        $��	DeleteReq��5.      $��Usuń wnioski��6"   $��Center=�69   $��1041,498,0,0q�6V   $	��Top=�6l   $��44��6�   $	��104��6�   6�   5/      50      