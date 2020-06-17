﻿using System;

namespace LocalInfoApp.Json
{

    // generated by Visual Studio to match json data result from sports api / rundown

    public class SportsEvents   // the root object
    {
        public Meta meta { get; set; }
        public Event[] events { get; set; }
    }

    public class Meta
    {
        public string delta_last_id { get; set; }
    }

    public class Event
    {
        public string event_id { get; set; }
        public int sport_id { get; set; }
        public DateTime event_date { get; set; }
        public int rotation_number_away { get; set; }
        public int rotation_number_home { get; set; }
        public Score score { get; set; }
        public Team[] teams { get; set; }
        public Teams_Normalized[] teams_normalized { get; set; }
        public Schedule schedule { get; set; }
        public Lines lines { get; set; }
        public Line_Periods line_periods { get; set; }
    }

    public class Score
    {
        public string event_id { get; set; }
        public string event_status { get; set; }
        public int score_away { get; set; }
        public int score_home { get; set; }
        public int winner_away { get; set; }
        public int winner_home { get; set; }
        public int[] score_away_by_period { get; set; }
        public int[] score_home_by_period { get; set; }
        public string venue_name { get; set; }
        public string venue_location { get; set; }
        public int game_clock { get; set; }
        public string display_clock { get; set; }
        public int game_period { get; set; }
        public string broadcast { get; set; }
        public string event_status_detail { get; set; }
    }

    public class Schedule
    {
        public string season_type { get; set; }
        public int season_year { get; set; }
        public string event_name { get; set; }
        public string attendance { get; set; }
    }

    public class Lines
    {
        public _7 _7 { get; set; }
        public _10 _10 { get; set; }
        public _17 _17 { get; set; }
        public _16 _16 { get; set; }
        public _14 _14 { get; set; }
        public _4 _4 { get; set; }
        public _15 _15 { get; set; }
        public _9 _9 { get; set; }
        public _3 _3 { get; set; }
        public _1 _1 { get; set; }
        public _2 _2 { get; set; }
        public _12 _12 { get; set; }
        public _6 _6 { get; set; }
        public _18 _18 { get; set; }
    }

    public class _7
    {
        public int line_id { get; set; }
        public Moneyline moneyline { get; set; }
        public Spread spread { get; set; }
        public Total total { get; set; }
        public Affiliate affiliate { get; set; }
    }

    public class Moneyline
    {
        public int line_id { get; set; }
        public int moneyline_away { get; set; }
        public int moneyline_away_delta { get; set; }
        public int moneyline_home { get; set; }
        public int moneyline_home_delta { get; set; }
        public float moneyline_draw { get; set; }
        public int moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public float point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public float point_spread_home_delta { get; set; }
        public float point_spread_away_money { get; set; }
        public float point_spread_away_money_delta { get; set; }
        public float point_spread_home_money { get; set; }
        public float point_spread_home_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Total
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public float total_over_delta { get; set; }
        public float total_under { get; set; }
        public float total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Affiliate
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class _10
    {
        public int line_id { get; set; }
        public Moneyline1 moneyline { get; set; }
        public Spread1 spread { get; set; }
        public Total1 total { get; set; }
        public Affiliate1 affiliate { get; set; }
    }

    public class Moneyline1
    {
        public int line_id { get; set; }
        public int moneyline_away { get; set; }
        public int moneyline_away_delta { get; set; }
        public int moneyline_home { get; set; }
        public int moneyline_home_delta { get; set; }
        public float moneyline_draw { get; set; }
        public int moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread1
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public float point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public float point_spread_home_delta { get; set; }
        public float point_spread_away_money { get; set; }
        public float point_spread_away_money_delta { get; set; }
        public float point_spread_home_money { get; set; }
        public float point_spread_home_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Total1
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public float total_over_delta { get; set; }
        public float total_under { get; set; }
        public float total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Affiliate1
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class _17
    {
        public int line_id { get; set; }
        public Moneyline2 moneyline { get; set; }
        public Spread2 spread { get; set; }
        public Total2 total { get; set; }
        public Affiliate2 affiliate { get; set; }
    }

    public class Moneyline2
    {
        public int line_id { get; set; }
        public int moneyline_away { get; set; }
        public int moneyline_away_delta { get; set; }
        public int moneyline_home { get; set; }
        public int moneyline_home_delta { get; set; }
        public float moneyline_draw { get; set; }
        public int moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread2
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public float point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public float point_spread_home_delta { get; set; }
        public float point_spread_away_money { get; set; }
        public float point_spread_away_money_delta { get; set; }
        public float point_spread_home_money { get; set; }
        public float point_spread_home_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Total2
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public float total_over_delta { get; set; }
        public float total_under { get; set; }
        public float total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Affiliate2
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class _16
    {
        public int line_id { get; set; }
        public Moneyline3 moneyline { get; set; }
        public Spread3 spread { get; set; }
        public Total3 total { get; set; }
        public Affiliate3 affiliate { get; set; }
    }

    public class Moneyline3
    {
        public int line_id { get; set; }
        public int moneyline_away { get; set; }
        public int moneyline_away_delta { get; set; }
        public int moneyline_home { get; set; }
        public int moneyline_home_delta { get; set; }
        public float moneyline_draw { get; set; }
        public int moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread3
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public int point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public int point_spread_home_delta { get; set; }
        public int point_spread_away_money { get; set; }
        public int point_spread_away_money_delta { get; set; }
        public int point_spread_home_money { get; set; }
        public int point_spread_home_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Total3
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public int total_over_delta { get; set; }
        public float total_under { get; set; }
        public int total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Affiliate3
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class _14
    {
        public int line_id { get; set; }
        public Moneyline4 moneyline { get; set; }
        public Spread4 spread { get; set; }
        public Total4 total { get; set; }
        public Affiliate4 affiliate { get; set; }
    }

    public class Moneyline4
    {
        public int line_id { get; set; }
        public int moneyline_away { get; set; }
        public int moneyline_away_delta { get; set; }
        public int moneyline_home { get; set; }
        public int moneyline_home_delta { get; set; }
        public float moneyline_draw { get; set; }
        public int moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread4
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public int point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public int point_spread_home_delta { get; set; }
        public int point_spread_away_money { get; set; }
        public int point_spread_away_money_delta { get; set; }
        public int point_spread_home_money { get; set; }
        public int point_spread_home_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Total4
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public int total_over_delta { get; set; }
        public float total_under { get; set; }
        public int total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Affiliate4
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class _4
    {
        public int line_id { get; set; }
        public Moneyline5 moneyline { get; set; }
        public Spread5 spread { get; set; }
        public Total5 total { get; set; }
        public Affiliate5 affiliate { get; set; }
    }

    public class Moneyline5
    {
        public int line_id { get; set; }
        public int moneyline_away { get; set; }
        public int moneyline_away_delta { get; set; }
        public int moneyline_home { get; set; }
        public int moneyline_home_delta { get; set; }
        public int moneyline_draw { get; set; }
        public int moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread5
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public int point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public int point_spread_home_delta { get; set; }
        public int point_spread_away_money { get; set; }
        public int point_spread_away_money_delta { get; set; }
        public int point_spread_home_money { get; set; }
        public int point_spread_home_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Total5
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public int total_over_delta { get; set; }
        public float total_under { get; set; }
        public int total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Affiliate5
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class _15
    {
        public int line_id { get; set; }
        public Moneyline6 moneyline { get; set; }
        public Spread6 spread { get; set; }
        public Total6 total { get; set; }
        public Affiliate6 affiliate { get; set; }
    }

    public class Moneyline6
    {
        public int line_id { get; set; }
        public int moneyline_away { get; set; }
        public int moneyline_away_delta { get; set; }
        public int moneyline_home { get; set; }
        public int moneyline_home_delta { get; set; }
        public float moneyline_draw { get; set; }
        public int moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread6
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public int point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public int point_spread_home_delta { get; set; }
        public int point_spread_away_money { get; set; }
        public int point_spread_away_money_delta { get; set; }
        public int point_spread_home_money { get; set; }
        public int point_spread_home_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Total6
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public int total_over_delta { get; set; }
        public float total_under { get; set; }
        public int total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Affiliate6
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class _9
    {
        public int line_id { get; set; }
        public Moneyline7 moneyline { get; set; }
        public Spread7 spread { get; set; }
        public Total7 total { get; set; }
        public Affiliate7 affiliate { get; set; }
    }

    public class Moneyline7
    {
        public int line_id { get; set; }
        public int moneyline_away { get; set; }
        public int moneyline_away_delta { get; set; }
        public int moneyline_home { get; set; }
        public int moneyline_home_delta { get; set; }
        public float moneyline_draw { get; set; }
        public int moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread7
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public float point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public float point_spread_home_delta { get; set; }
        public float point_spread_away_money { get; set; }
        public float point_spread_away_money_delta { get; set; }
        public float point_spread_home_money { get; set; }
        public float point_spread_home_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Total7
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public float total_over_delta { get; set; }
        public float total_under { get; set; }
        public float total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Affiliate7
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class _3
    {
        public int line_id { get; set; }
        public Moneyline8 moneyline { get; set; }
        public Spread8 spread { get; set; }
        public Total8 total { get; set; }
        public Affiliate8 affiliate { get; set; }
    }

    public class Moneyline8
    {
        public int line_id { get; set; }
        public int moneyline_away { get; set; }
        public int moneyline_away_delta { get; set; }
        public int moneyline_home { get; set; }
        public int moneyline_home_delta { get; set; }
        public float moneyline_draw { get; set; }
        public int moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread8
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public int point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public int point_spread_home_delta { get; set; }
        public int point_spread_away_money { get; set; }
        public int point_spread_away_money_delta { get; set; }
        public int point_spread_home_money { get; set; }
        public int point_spread_home_money_delta { get; set; }
        public Extended_Spreads[] extended_spreads { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Extended_Spreads
    {
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public int point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public int point_spread_home_delta { get; set; }
        public int point_spread_away_money { get; set; }
        public int point_spread_away_money_delta { get; set; }
        public int point_spread_home_money { get; set; }
        public int point_spread_home_money_delta { get; set; }
    }

    public class Total8
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public float total_over_delta { get; set; }
        public float total_under { get; set; }
        public float total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
        public Extended_Totals[] extended_totals { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Extended_Totals
    {
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public int total_over_delta { get; set; }
        public float total_under { get; set; }
        public int total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
    }

    public class Affiliate8
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class _1
    {
        public int line_id { get; set; }
        public Moneyline9 moneyline { get; set; }
        public Spread9 spread { get; set; }
        public Total9 total { get; set; }
        public Affiliate9 affiliate { get; set; }
    }

    public class Moneyline9
    {
        public int line_id { get; set; }
        public int moneyline_away { get; set; }
        public int moneyline_away_delta { get; set; }
        public int moneyline_home { get; set; }
        public int moneyline_home_delta { get; set; }
        public float moneyline_draw { get; set; }
        public int moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread9
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public int point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public int point_spread_home_delta { get; set; }
        public int point_spread_away_money { get; set; }
        public int point_spread_away_money_delta { get; set; }
        public int point_spread_home_money { get; set; }
        public int point_spread_home_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Total9
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public int total_over_delta { get; set; }
        public float total_under { get; set; }
        public int total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Affiliate9
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class _2
    {
        public int line_id { get; set; }
        public Moneyline10 moneyline { get; set; }
        public Spread10 spread { get; set; }
        public Total10 total { get; set; }
        public Affiliate10 affiliate { get; set; }
    }

    public class Moneyline10
    {
        public int line_id { get; set; }
        public int moneyline_away { get; set; }
        public int moneyline_away_delta { get; set; }
        public int moneyline_home { get; set; }
        public int moneyline_home_delta { get; set; }
        public float moneyline_draw { get; set; }
        public int moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread10
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public int point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public int point_spread_home_delta { get; set; }
        public int point_spread_away_money { get; set; }
        public int point_spread_away_money_delta { get; set; }
        public int point_spread_home_money { get; set; }
        public int point_spread_home_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Total10
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public float total_over_delta { get; set; }
        public float total_under { get; set; }
        public float total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Affiliate10
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class _12
    {
        public int line_id { get; set; }
        public Moneyline11 moneyline { get; set; }
        public Spread11 spread { get; set; }
        public Total11 total { get; set; }
        public Affiliate11 affiliate { get; set; }
    }

    public class Moneyline11
    {
        public int line_id { get; set; }
        public int moneyline_away { get; set; }
        public int moneyline_away_delta { get; set; }
        public int moneyline_home { get; set; }
        public int moneyline_home_delta { get; set; }
        public float moneyline_draw { get; set; }
        public int moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread11
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public int point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public int point_spread_home_delta { get; set; }
        public int point_spread_away_money { get; set; }
        public int point_spread_away_money_delta { get; set; }
        public int point_spread_home_money { get; set; }
        public int point_spread_home_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Total11
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public float total_over_delta { get; set; }
        public float total_under { get; set; }
        public float total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Affiliate11
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class _6
    {
        public int line_id { get; set; }
        public Moneyline12 moneyline { get; set; }
        public Spread12 spread { get; set; }
        public Total12 total { get; set; }
        public Affiliate12 affiliate { get; set; }
    }

    public class Moneyline12
    {
        public int line_id { get; set; }
        public int moneyline_away { get; set; }
        public int moneyline_away_delta { get; set; }
        public int moneyline_home { get; set; }
        public int moneyline_home_delta { get; set; }
        public int moneyline_draw { get; set; }
        public int moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread12
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public int point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public int point_spread_home_delta { get; set; }
        public int point_spread_away_money { get; set; }
        public int point_spread_away_money_delta { get; set; }
        public int point_spread_home_money { get; set; }
        public int point_spread_home_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Total12
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public int total_over_delta { get; set; }
        public float total_under { get; set; }
        public int total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Affiliate12
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class _18
    {
        public int line_id { get; set; }
        public Moneyline13 moneyline { get; set; }
        public Spread13 spread { get; set; }
        public Total13 total { get; set; }
        public Affiliate13 affiliate { get; set; }
    }

    public class Moneyline13
    {
        public int line_id { get; set; }
        public int moneyline_away { get; set; }
        public int moneyline_away_delta { get; set; }
        public int moneyline_home { get; set; }
        public int moneyline_home_delta { get; set; }
        public float moneyline_draw { get; set; }
        public int moneyline_draw_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Spread13
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float point_spread_away { get; set; }
        public int point_spread_away_delta { get; set; }
        public float point_spread_home { get; set; }
        public int point_spread_home_delta { get; set; }
        public int point_spread_away_money { get; set; }
        public int point_spread_away_money_delta { get; set; }
        public int point_spread_home_money { get; set; }
        public int point_spread_home_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Total13
    {
        public int line_id { get; set; }
        public string event_id { get; set; }
        public int affiliate_id { get; set; }
        public float total_over { get; set; }
        public int total_over_delta { get; set; }
        public float total_under { get; set; }
        public int total_under_delta { get; set; }
        public int total_over_money { get; set; }
        public int total_over_money_delta { get; set; }
        public int total_under_money { get; set; }
        public int total_under_money_delta { get; set; }
        public DateTime date_updated { get; set; }
        public string format { get; set; }
    }

    public class Affiliate13
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_url { get; set; }
    }

    public class Line_Periods
    {
    }

    public class Team
    {
        public int team_id { get; set; }
        public int team_normalized_id { get; set; }
        public string name { get; set; }
        public bool is_away { get; set; }
        public bool is_home { get; set; }
    }

    public class Teams_Normalized
    {
        public int team_id { get; set; }
        public string name { get; set; }
        public string mascot { get; set; }
        public string abbreviation { get; set; }
        public int ranking { get; set; }
        public string record { get; set; }
        public bool is_away { get; set; }
        public bool is_home { get; set; }
    }
}